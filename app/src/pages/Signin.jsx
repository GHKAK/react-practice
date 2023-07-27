import { useState } from "react";
import { Link } from "react-router-dom";

function Signin({ setSignIn }) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleSignIn = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("https://localhost:7178/api/auth/signin", {
        method: "POST",
        headers: {
          "Content-type": "application/json",
        },
        body: JSON.stringify({ username, password }),
      });
      const token = await response.json();
      localStorage.setItem("jwtToken", token);
      setSignIn(true);
    } catch (error) {
      console.error(error);
    }
  };
  return (
    <div className="sign-container">
      <Link to="/" className="logo">
        Dashboard
      </Link>{" "}
      <h2>Sign In</h2>
      <form onSubmit={handleSignIn}>
        <div className="input-container">
          <label>Username/Email:</label>
          <input
            className="google-input"
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </div>
        <div className="input-container">
          <label>Password:</label>
          <input
            className="google-input"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <div className="sign-buttons-container">
          <button className="btn btn-primary signup-btn">
            Sign Up
          </button>
          <button type="submit" className="btn btn-primary signin-btn">
            Sign In
          </button>
        </div>
      </form>
    </div>
  );
}
export default Signin;
