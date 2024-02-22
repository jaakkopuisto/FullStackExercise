/* eslint-disable react/jsx-key */
import { useEffect, useState } from 'react';

function Products() {
    let [currentProductData, setProductData] = useState();
    let [originalProductData, setOriginalProductData] = useState();

    useEffect(() => {
        getJsonData();
    }, []);

    let contents = currentProductData === undefined
        ? <p><em>Loading json data</em></p>
        : <div className="products-parent">
            {currentProductData.map((item) =>
                <div className="product-card">
                    <div className="product-image-container">
                        <img className="product-img" src={item.images[0]}></img>
                    </div>

                    <h4>{item.title}</h4>
                    <span className="product-description">{item.description}</span>
                    <h5 className="product-price">{item.price}&euro;</h5>
                </div>
            )}
        </div>;

    return (
        <div>
            <h2>Products</h2>
            <div className="form-group mb-2 input-size-medium">
                <div className="input-group mb-3">
                    <input type="text" placeholder="Search by title" id="searchField" className="form-control input-field-medium"></input>
                    <div className="input-group-append">
                        <button className="btn btn-outline-primary" type="button" onClick={searchByTitle}>Search</button>
                    </div>
                </div>
            </div>
            {contents}
        </div>

    ); // TODO: Mikä helvetti on key? ja miks semmone pitää olla unique

    function searchByTitle() {
        const searchField = document.getElementById("searchField");

        if (searchField) {
            var filteredProducts = originalProductData.filter(x => x.title.toLowerCase().includes(searchField.value.toLowerCase()));
            setProductData(filteredProducts);
        }
    }

    async function getJsonData() {
        const response = await fetch('products');
        const data = await response.json();
        var tempData = data.products;

        setOriginalProductData(tempData);
        setProductData(tempData);
    }

}

export default Products;