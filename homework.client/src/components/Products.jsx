import { useEffect, useState } from 'react';
import Spinner from "./Spinner";

function Products() {
    const [currentProductData, setProductData] = useState();
    const [originalProductData, setOriginalProductData] = useState();
    const [isLoading, setLoading] = useState();
    const [isEmpty, setEmpty] = useState();
    const [error, setError] = useState();

    useEffect(() => {
        getJsonData();
    }, []);

    const onFormSubmit = async (e) => {
        try {
            e.preventDefault();
            searchByTitle();
        }
        catch (err) {
            console.error(err);
        }
    }

    let contents = currentProductData === undefined
        ? <p><em>Loading json data</em></p>
        : <div className="products-parent">
            {currentProductData.map((item) =>
                <div key={item.id} className="product-card">
                    <div className="product-image-container">
                        <img className="product-img" src={item.images[0]}></img>
                    </div>

                    <h4>{item.title}</h4>
                    <span className="product-description">{item.description}</span>
                    <h5 className="product-price">{item.price}&euro;</h5>
                </div>
            )}
        </div>;

    // State handling
    if (isLoading) {
        return <div>
            <Spinner loadingText="Loading products..."></Spinner>
        </div>
    }
    else if (isEmpty) {
        return (
            <div>
                <h2>Products</h2>
                <div className="form-group mb-2 input-size-medium">
                    <form id="1" onSubmit={onFormSubmit}>
                        <div className="input-group mb-3">
                            <input type="text" placeholder="Search by title" id="searchField" className="form-control input-field-medium searchField"></input>
                            <div className="input-group-append">
                                <button className="btn btn-outline-primary" type="submit">Search</button>
                            </div>
                        </div>
                    </form>
                </div>
                <span>0 Results</span>
            </div>
        )
    }
    else if (error) {
        return <div>There was an error loading the page. :(</div>
    }
    else {
        return (
            <div>
                <h2>Products</h2>
                <div className="form-group mb-2 input-size-medium">
                    <form id="1" onSubmit={onFormSubmit}>
                        <div className="input-group mb-3">
                            <input type="text" placeholder="Search by title" id="searchField" className="form-control input-field-medium searchField"></input>
                            <div className="input-group-append">
                                <button className="btn btn-outline-primary" type="submit">Search</button>
                            </div>
                        </div>
                    </form>
                </div>
                {contents}
            </div>
        )
    }

    function searchByTitle() {
        const searchField = document.getElementById("searchField");

        if (searchField) {
            var filteredProducts = originalProductData.filter(x => x.title.toLowerCase().includes(searchField.value.toLowerCase()));

            if (filteredProducts.length > 0) {
                setProductData(filteredProducts);
                setEmpty(false);
            }
            else
                setEmpty(true);
        }
    }

    async function getJsonData() {
        setLoading(true);
        try {
            const response = await fetch('products');
            const data = await response.json();
            var productList = data.products;

            if (productList != null) {
                setOriginalProductData(productList);
                setProductData(productList);
            }
            else {
                setEmpty(true);
            }
        }
        catch (err) {
            setError(err);
        }
        finally {
            setLoading(false);
        }
    }
}

export default Products;