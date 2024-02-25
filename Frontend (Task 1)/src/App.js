import React, { useState } from "react";
import './styles/App.css';
import ProductList from "./components/ProductList";
import ProductInput from "./components/ProductInput";

function App() {
  const [products, setProducts] = useState([]);

  return (
    <div className="App">
      <ProductInput/>
      <ProductList 
        products={products}
        setProducts={setProducts}
        title="Products list"
      />
    </div>
  );
}

export default App;
