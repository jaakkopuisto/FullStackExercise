import { useState, useEffect } from "react";

export async function useFetchData() {
    const [data, setdata] = useState(null);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);


    setLoading(true);
    const response = await fetch('products');
    data(await response.json());
    var tempData = data.products;

    setOriginalProductData(tempData);
    setProductData(tempData);
    setLoading(false);

    return { data, loading, error }
}