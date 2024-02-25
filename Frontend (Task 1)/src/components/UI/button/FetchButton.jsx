import React from 'react';
import axios from "axios";
import './FetchButton.css';

const FetchButton = ({setProducts}) => {

  const fetchData = async () => {
      const response = await axios.get("https://localhost:7256/api/Products/get-filtered-data");
      console.log(response.data);
      setProducts(response.data);
  };

  return (
    <button className="fetch-button" 
      onClick={fetchData}
    >
      Fetch Data
    </button>
  );
};

export default FetchButton;