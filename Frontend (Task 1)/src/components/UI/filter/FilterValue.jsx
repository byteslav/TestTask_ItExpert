import React, { useState } from 'react';
import './FilterValue.css';

const FilterValue = ({ label, onChange, validation }) => {
  const [value, setValue] = useState('');
  const [error, setError] = useState('');

  const handleChange = (e) => {
    const inputValue = e.target.value;
    setValue(inputValue);

    if (validation && !validation(inputValue)) {
      setError('Invalid value');
    } else {
      setError('');
      onChange(inputValue);
    }
  };

  return (
    <div className="filter-value">
      <label className="filter-label">{label}:</label>
      <input
        type="text"
        className={`filter-input ${error && 'error'}`}
        value={value}
        onChange={handleChange}
      />
      {error && <span className="error-message">{error}</span>}
    </div>
  );
};

export default FilterValue;