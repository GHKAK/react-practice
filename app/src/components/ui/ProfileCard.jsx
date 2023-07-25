import Avatar from "./Avatar";
import CardDivider from "./CardDivider";
import ProfileCardButton from "./ProfileCardButton";
import Contact from "./Contact";
import ContactList from "./ContactList";
import ProfileCardInfo from "./ProfileCardInfo";
import ProgressBar from "./ProgressBar";

function ProfileCard() {
  return (
    <div className="card profile-card">
      <ProfileCardButton />
      <div className="profile-card-wrapper">
        <Avatar size={48} />
        <ProfileCardInfo />
      </div>
      <ContactList />
      <CardDivider />
      <ul className="progress-list">
        <li className="progress-item">
          <ProgressBar value = {85} isPercentage/>
        </li>
        <li className="progress-item">
        <ProgressBar value = {7.5} />
        </li>
      </ul>
    </div>
  );
}
export default ProfileCard;
