function TaskCard({ task, deadline, progress, commentsCount, priority }) {
  const priorityColorMap = {
    High: "red",
    Medium: "orange",
    Low: "green",
  };
  return (
    <li className="tasks-item">
      <div className="card task-card">
        <div className="card-input">
          <input type="checkbox" name="task-1" id="task-1" />
          <label htmlFor="task-1" className="task-label">
            {task}
          </label>
        </div>
        <div
          className={`card-badge ${
            deadline.startsWith("Today") ? "cyan" : ""
          } radius-pill`}
        >
          {deadline}
        </div>
        <ul className="card-meta-list">
          <li>
            <div className="meta-box icon-box">
              <span className="material-symbols-rounded  icon">list</span>
              <span>{progress}</span>
            </div>
          </li>
          <li>
            <div className="meta-box icon-box">
              <span className="material-symbols-rounded  icon">comment</span>
              <data value={commentsCount}>{commentsCount}</data>
            </div>
          </li>
          <li>
            <div className={`card-badge ${priorityColorMap[priority]}`}>
              {priority}
            </div>
          </li>
        </ul>
      </div>
    </li>
  );
}
export default TaskCard;
