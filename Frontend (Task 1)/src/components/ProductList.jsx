import React from "react";
import ProductItem from "./ProductItem";
import FetchButton from "./UI/button/FetchButton";
import '../styles/ProductList.css';

const ProductList = ({products, setProducts, title}) => {

    return (
        <div className="product-list-container">
            <h2 className="product-list-title">{title}</h2>
            <FetchButton setProducts={setProducts}/>
            <div className="product-list">
                {products.map(product => (
                <ProductItem product={product} key={product.id} />
                ))}
            </div>
        </div>
    );
};

export default ProductList;