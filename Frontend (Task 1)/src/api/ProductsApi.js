import axios from 'axios';

const BASE_URL = 'https://localhost:7256/api/Products/';

export const fetchProducts = async (filtersArray) => {

  return await axios.get(BASE_URL + 'get-filtered-data', {params: filtersArray})
    .then(response => response.data)
    .catch(error => {
      console.error('Error fetching products:', error.message);
      throw error;
    });
};

// Function to add a new product to the server
export const addProduct = async (newProducts) => {
  try {
    await axios.post(BASE_URL + 'insert-array', newProducts);
  } catch (error) {
    console.error('Error adding product:', error.message);
    throw error;
  }
};
