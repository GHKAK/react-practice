import { Link,NavLink } from 'react-router-dom'
import '../../assets/css/style.css'
import { useState } from 'react';
import Avatar from './Avatar';
export function Header() {
    const [isActiveBurger,setIsActiveBurger] = useState(false);
    const toggleNavBurger=()=>{
        setIsActiveBurger(!isActiveBurger);
    }
    return (
        <header className= {`header ${isActiveBurger?"active":""}`} data-header>
            <div className="container">
                <h1>
                    <Link to="/" className="logo">
                        Dashboard
                    </Link>
                </h1>
                <button
                    onClick={toggleNavBurger}
                    className="menu-toggle-btn icon-box"
                    data-menu-toggle-btn=""
                    aria-label="Toggle Menu"
                >
                    <span className="material-symbols-rounded  icon">menu</span>
                </button>
                <nav className="navbar">
                    <div className="container">
                        <ul className="navbar-list">
                            <li>
                                <NavLink to="/" activeClassName="active" className="navbar-link icon-box">
                                    <span className="material-symbols-rounded  icon">grid_view</span>
                                    <span>Home</span>
                                </NavLink>
                            </li>
                            <li>
                                <NavLink to="/projects" activeClassName="active" className="navbar-link icon-box">
                                    <span className="material-symbols-rounded  icon">folder</span>
                                    <span>Projects</span>
                                </NavLink>
                            </li>
                            <li>
                                <NavLink to="/tasks" activeClassName="active" className="navbar-link icon-box">
                                    <span className="material-symbols-rounded  icon">list</span>
                                    <span>Tasks</span>
                                </NavLink>
                            </li>
                            <li>
                                <NavLink to="/reports" activeClassName="active" className="navbar-link icon-box">
                                    <span className="material-symbols-rounded  icon">bar_chart</span>
                                    <span>Reports</span>
                                </NavLink>
                            </li>
                            <li>
                                <NavLink to="/settings" activeClassName="active" className="navbar-link icon-box">
                                    <span className="material-symbols-rounded  icon">settings</span>
                                    <span>Settings</span>
                                </NavLink>
                            </li>
                        </ul>
                        <ul className="user-action-list">
                            <li>
                                <a href="#" className="notification icon-box">
                                    <span className="material-symbols-rounded  icon">
                                        notifications
                                    </span>
                                </a>
                            </li>
                            <li>
                                <a href="#" className="header-profile">
                                    <Avatar size={32}/>
                                    <div>
                                        <p className="profile-title">Elizabeth F</p>
                                        <p className="profile-subtitle">Admin</p>
                                    </div>
                                </a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </header>
    )
}   