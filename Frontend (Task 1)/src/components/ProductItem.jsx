import React from "react";

const ProductItem = (props) => {
    return (
        <div className="product">
            <div className="product__content">
                <strong>{props.product.code}. {props.product.value}</strong>
            </div>
      </div>
    );
};

export default ProductItem;