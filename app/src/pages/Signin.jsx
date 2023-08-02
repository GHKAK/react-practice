import { useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";

function Signin({ setSignIn }) {
  const navigate = useNavigate();
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

   useEffect(() => {
    const token = localStorage.getItem("jwtToken");
    const tok = JSON.parse(token)["token"];

    fetch("https://localhost:7178/api/Auth/validate-token", {
      method: "POST",
      headers: {
        Authorization: `Bearer ${tok}`,
        "Content-Type": "application/json",
      },
    }).then(response => {
      if(response.ok){
        setSignIn(true);
      }
    })
  },[setSignIn]);
  const handleSignIn = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("https://localhost:7178/api/Auth/signin", {
        method: "POST",
        headers: {
          "Content-type": "application/json",
        },
        body: JSON.stringify({ username, password }),
      });
      const token = await response.json();
      localStorage.setItem("jwtToken", JSON.stringify(token));
      setSignIn(true);
    } catch (error) {
      console.error(error);
    }
  };
  return (
    <div className="sign-container">
      <Link tabIndex={1} to="/" className="logo">
        Dashboard
      </Link>{" "}
      <h2>Sign In</h2>
      <form onSubmit={handleSignIn}>
        <div className="input-container">
          <label>Username/Email:</label>
          <input
            tabIndex={2}
            className="google-input"
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div className="input-container">
          <label>Password:</label>
          <input
            tabIndex={2}
            className="google-input"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <div className="sign-buttons-container">
          <button tabIndex={3} className="btn btn-primary signup-btn">
            Sign Up
          </button>
          <button type="submit" tabIndex={2} className="btn btn-primary signin-btn">
            Sign In
          </button>
        </div>
      </form>
    </div>
  );
}
export default Signin;
