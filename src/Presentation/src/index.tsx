import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Main from './Main';
import React from 'react';
import ReactDOM from 'react-dom/client';
import Details from './Components/Details';



const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <BrowserRouter>
    <React.StrictMode>
      <Routes>
        <Route path='/Details/:id/:name' element={<Details />} />
        <Route path='/' element={<Main />} />
      </Routes>
    </React.StrictMode>
  </BrowserRouter>
);


