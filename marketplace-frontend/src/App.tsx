import { useEffect, useState } from "react";

interface Product {
  id: number;
  name: string;
  price: number;
  description?: string;
}

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch('http://localhost:5185/api/products')
    .then(response => response.json())
    .then(data => setProducts(data))
    .catch(error => console.error('Error while getting data', error))
  }, []);

  return (
    <div style={{ padding: '20px', fontFamily: 'sans-serif' }}>
      <h1>Маркетплейс</h1>
      <h2>Список товаров из базы данных MySQL:</h2>
      
      <div style={{ display: 'flex', gap: '20px', flexWrap: 'wrap' }}>
        {products.map(product => (
          <div key={product.id} style={{ border: '1px solid #ccc', padding: '15px', borderRadius: '8px', width: '200px' }}>
            <h3>{product.name}</h3>
            <p><b>Цена:</b> {product.price} руб.</p>
            <p>{product.description || <i>Нет описания</i>}</p>
          </div>
        ))}
      </div>
    </div>
  )
}

export default App