import { useState } from "react";

function RecentProjectButton() {
    const [isToggled,setIsToggled] = useState(false);
    const handleToggle = () => setIsToggled(!isToggled);
  return (
    <>
      {" "}
      <button
        onClick={handleToggle}
        className="card-menu-btn icon-box"
        aria-label="More"
        data-menu-btn=""
      >
        <span className="material-symbols-rounded  icon">more_horiz</span>
      </button>
      <ul className={`ctx-menu ${isToggled?'active':''}`}>
        <li className="ctx-item">
          <button className="ctx-menu-btn icon-box">
            <span className="material-symbols-rounded  icon" aria-hidden="true">
              visibility
            </span>
            <span className="ctx-menu-text">View</span>
          </button>
        </li>
        <li className="ctx-item">
          <button className="ctx-menu-btn icon-box">
            <span className="material-symbols-rounded  icon" aria-hidden="true">
              edit
            </span>
            <span className="ctx-menu-text">Edit</span>
          </button>
        </li>
        <li className="divider" />
        <li className="ctx-item">
          <button className="ctx-menu-btn red icon-box">
            <span className="material-symbols-rounded  icon" aria-hidden="true">
              delete
            </span>
            <span className="ctx-menu-text">Delete</span>
          </button>
        </li>
      </ul>
    </>
  );
}
export default RecentProjectButton;
