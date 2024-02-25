import React from "react";
import '../styles/ProductItem.css'

const ProductItem = (props) => {
    return (
            <div className="product-container">
                <h2>Product №{props.product.id}</h2>
                <div className="product-details">
                    <div className="product-field">
                        <label>Code:</label>
                        <span>{props.product.code}</span>
                    </div>
                    <div className="product-field">
                        <label>Value:</label>
                        <span>{props.product.value}</span>
                    </div>
                </div>
            </div>
    );
};

export default ProductItem;