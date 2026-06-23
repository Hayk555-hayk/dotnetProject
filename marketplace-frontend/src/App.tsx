import { useEffect, useState } from "react";

interface Product {
  id: number;
  name: string;
  price: number;
  description?: string;
}

function App() {
  const [products, setProducts] = useState<Product[]>([]);
  const [search, setSearch] = useState('');
  const [maxPrice, setMaxPrice] = useState('');

  const fetchProducts = () => {
    const url = new URL('http://localhost:5185/api/products');

    if (search) url.searchParams.append('search', search);
    if (maxPrice) url.searchParams.append('maxPrice', maxPrice);

    fetch(url.toString())
      .then(response => response.json())
      .then(data => setProducts(data))
      .catch(error => console.error('Error while getting data', error))
  }


  useEffect(() => {
    fetchProducts();
  }, []);


  const handleFilterSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    fetchProducts();
  }

  return (
    <div style={{ padding: '20px', fontFamily: 'sans-serif' }}>
      <h1>Маркетплейс</h1>

      <form onSubmit={handleFilterSubmit} style={{ display: 'flex', gap: '15px', marginBottom: '30px', alignItems: 'flex-end' }}>
        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Поиск по названию:</label>
          <input
            type="text"
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            placeholder="Например: Телефон"
            style={{ padding: '8px', borderRadius: '4px', border: '1px solid #ccc' }}
          />
        </div>

        <div>
          <label style={{ display: 'block', marginBottom: '5px' }}>Макс. цена (руб):</label>
          <input
            type="number"
            value={maxPrice}
            onChange={(e) => setMaxPrice(e.target.value)}
            placeholder="60000"
            style={{ padding: '8px', borderRadius: '4px', border: '1px solid #ccc' }}
          />
        </div>

        <button type="submit" style={{ padding: '9px 15px', backgroundColor: '#007bff', color: '#fff', border: 'none', borderRadius: '4px', cursor: 'pointer' }}>
          Применить
        </button>
      </form>

      <h2>Список товаров из базы данных MySQL:</h2>

      <div style={{ display: 'flex', gap: '20px', flexWrap: 'wrap' }}>
        {products.length > 0 ? products.map(product => (
          <div key={product.id} style={{ border: '1px solid #ccc', padding: '15px', borderRadius: '8px', width: '200px' }}>
            <h3>{product.name}</h3>
            <p><b>Цена:</b> {product.price} руб.</p>
            <p>{product.description || <i>Нет описания</i>}</p>
          </div>
        )) : <p>Товары не найдены по заданным фильтрам 😢</p> }
      </div>
    </div>
  )
}

export default App