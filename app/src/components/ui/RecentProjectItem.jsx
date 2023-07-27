import AvatarLinkItem from "./AvatarLinkItem";
import ProgressBar from "./ProgressBar";
import RecentProjectButton from "./RecentProjectButton";

function RecentProjectItem({
  date,
  title,
  description,
  stage,
  progressPercentage,
}) {
  const dateNew = new Date(date);
  const stageColorMap = {
    Designing: "blue",
    Planning: "orange",
    Development: "cyan",
  };
  const options = { year: "numeric", month: "short", day: "2-digit" };
  const formattedDate = new Intl.DateTimeFormat("en-US", options).format(
    dateNew
  );
  return (
    <li className="project-item">
      <div className="card project-card">
        <RecentProjectButton />
        <time className="card-date" dateTime="2022-04-09">
          {formattedDate}
        </time>
        <h3 className="card-title">
          <a href="#">{title}</a>
        </h3>
        <div className={`card-badge ${stageColorMap[stage]}`}>{stage}</div>
        <p className="card-text">{description}</p>
        <ProgressBar value={progressPercentage} isPercentage />
        <ul className="card-avatar-list">
          <AvatarLinkItem name="Elizabeth Foster" uid={1} />
          <AvatarLinkItem name="John Foster" uid={2} />
        </ul>
      </div>
    </li>
  );
}
export default RecentProjectItem;
