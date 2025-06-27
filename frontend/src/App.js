import logo from './logo.svg';
import './App.css';
import React, { useState } from 'react';

function App() {

  const[joke,setJoke]=useState('');

  const fetchJoke=async()=>{
    const res=await fetch("http://localhost:5212/api/jokes/random");
    const data=await res.json();
    setJoke(data.text);
  }


  return (
    <div style={{padding:40}}>
      <h1>DevOps Joke Dashboard</h1>
      <button onClick={fetchJoke}>Get a Joke</button>
      <p style={{marginTop:20}}>{joke}</p>
    </div>
    // <div className="App">
    //   <header className="App-header">
    //     <img src={logo} className="App-logo" alt="logo" />
    //     <p>
    //       Edit <code>src/App.js</code> and save to reload.
    //     </p>
    //     <a
    //       className="App-link"
    //       href="https://reactjs.org"
    //       target="_blank"
    //       rel="noopener noreferrer"
    //     >
    //       Learn React
    //     </a>
    //   </header>
    // </div>
  );
}

export default App;
