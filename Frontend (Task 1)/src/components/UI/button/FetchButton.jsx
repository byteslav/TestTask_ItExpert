import React, { useState } from 'react';
import './FetchButton.css';
import { fetchProducts } from '../../../api/ProductsApi';
import FilterValue from '../filter/FilterValue';

const FetchButton = ({setProducts}) => {
  const [filters, setFilters] = useState({});
  const [validationError, setValidationError] = useState(false);

  const fetchData = async (filtersArray) => {
      const products = await fetchProducts(filtersArray);
      setProducts(products);
  };

  const handleFilterChange = (key, filterValue) => {
    setFilters(prevFilters => ({
      ...prevFilters,
      [key]: filterValue
    }));
  };

  const validateCode = (value) => {
    const isValid = Number.isInteger(Number(value));
    setValidationError(!isValid);
    return isValid;
  };

  return (
    <div className="fetch-button-container">
      <div className="filter-value-wrapper">
        <FilterValue label="Value" onChange={(value) => handleFilterChange('value', value)} />
      </div>
      <div className="filter-value-wrapper">
        <FilterValue label="Code" onChange={(value) => handleFilterChange('code', value)} validation={validateCode}/>
      </div>
      <button className="fetch-button" onClick={() => fetchData(filters)} disabled={validationError}>
        Fetch Data
      </button>
    </div>
  );
};

export default FetchButton;