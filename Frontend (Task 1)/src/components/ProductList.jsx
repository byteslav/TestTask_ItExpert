import React from "react";
import ProductItem from "./ProductItem";

const ProductList = ({products}, title) => {
    return (
        <div>
            <h1 style={{textAlign: "center"}}>Products list</h1>
            {products.map(product =>
                <ProductItem product={product} key={product.id}/>
            )};
        </div>
    );
};

export default ProductList;