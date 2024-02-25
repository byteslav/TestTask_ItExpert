import React, { useState } from 'react';
import '../styles/ProductInput.css';

const ProductInput = () => {
  const [products, setProducts] = useState([{ code: '', value: '' }]);

  const handleChange = (index, key, value) => {
    const newProducts = [...products];
    newProducts[index][key] = value;
    setProducts(newProducts);
  };

  const handleAddProduct = () => {
    setProducts([...products, { code: '', value: '' }]);
  };

  const handleRemoveProduct = (index) => {
    const newProducts = products.filter((_, i) => i !== index);
    setProducts(newProducts);
  };

  const handleSubmit = () => {
    const jsonData = products.map(({ code, value }) => ({ [code]: value }));
    console.log(jsonData);
    // Here I'll send data to the server

    setProducts([{ code: '', value: '' }]);
  };

  return (
    <div className="product-input-container">
      <div className="product-input-title">
        <h2>You can add Products right here!</h2>
      </div>
      {products.map((product, index) => (
        <div className="product-input" key={index}>
          <input
            className="product-input-field"
            type="text"
            value={product.code}
            onChange={(e) => handleChange(index, 'code', e.target.value)}
            placeholder="Code"
          />
          <input
            className="product-input-field"
            type="text"
            value={product.value}
            onChange={(e) => handleChange(index, 'value', e.target.value)}
            placeholder="Value"
          />
          <button className="remove-product-button" onClick={() => handleRemoveProduct(index)}>Remove</button>
        </div>
      ))}
      <button className="add-product-button" onClick={handleAddProduct}>Add Product</button>
      <button className="submit-button" onClick={handleSubmit}>Submit</button>
    </div>
  );
};

export default ProductInput;