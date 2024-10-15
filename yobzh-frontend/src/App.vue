<!-- App.vue -->
<template>
  <div class="container mt-4">
    <h1 class="mb-4">Product Management</h1>
    <button class="btn btn-primary mb-3" @click="showAddModal">Add Product</button>
    <div class="row">
      <div v-for="product in products" :key="product.id" class="col-md-4 mb-3">
        <div class="card">
          <div class="card-body">
            <h5 class="card-title">{{ product.name }}</h5>
            <p class="card-text">{{ product.description }}</p>
            <p class="card-text"><strong>Price: ${{ product.price.toFixed(2) }}</strong></p>
            <button class="btn btn-warning me-2" @click="showUpdateModal(product)">Update</button>
            <button class="btn btn-danger" @click="deleteProduct(product.id)">Delete</button>
          </div>
        </div>
      </div>
    </div>
    <ProductModal
      v-if="showModal"
      :product="currentProduct"
      @close="closeModal"
      @save="saveProduct"
    />
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import axios from 'axios';
import ProductModal from './components/ProductModal.vue';

const products = ref([]);
const showModal = ref(false);
const currentProduct = ref({});

const fetchProducts = async () => {
  try {
    const response = await axios.get('https://localhost:7141/products');
    products.value = response.data;
  } catch (error) {
    console.error('Error fetching products:', error);
  }
};

const showAddModal = () => {
  currentProduct.value = {};
  showModal.value = true;
};

const showUpdateModal = (product) => {
  currentProduct.value = { ...product };
  showModal.value = true;
};

const closeModal = () => {
  showModal.value = false;
};

const saveProduct = async (product) => {
  try {
    if (product.id) {
      await axios.put('https://localhost:7141/products', product);
    } else {
      await axios.post('https://localhost:7141/products', product);
    }
    await fetchProducts();
    closeModal();
  } catch (error) {
    console.error('Error saving product:', error);
  }
};

const deleteProduct = async (id) => {
  if (confirm('Are you sure you want to delete this product?')) {
    try {
      await axios.delete(`https://localhost:7141/products/${id}`);
      await fetchProducts();
    } catch (error) {
      console.error('Error deleting product:', error);
    }
  }
};

onMounted(fetchProducts);
</script>