import React, { useState } from "react";
import './styles/App.css';
import ProductList from "./components/ProductList";
import MyButton from "./components/UI/button/MyButton";
import MyInput from "./components/UI/input/MyInput";
import axios from "axios";

function App() {
  const [products, setProducts] = useState([]);

  const [title, setTitle] = useState('');
  const addNewProduct = (e) => {
    e.preventDefault();
  };

  async function fetchProducts() {
    const response = await axios.get("https://localhost:7256/api/Products/get-filtered-data");
    console.log(response.data);
    setProducts(response.data);
  }

  return (
    <div className="App">
      <button onClick={fetchProducts}>Get Product</button>
      <form>
        <MyInput 
          value={title}
          onChange={e => setTitle(e.target.value)}
          type="text" 
          placeholder="Product name"
          />
        <MyInput type="text" placeholder="Product description"/>
        <MyButton onClick={addNewProduct}>Create Product</MyButton>
      </form>
      <ProductList products={products} title="Products list"/>
    </div>
  );
}

export default App;
