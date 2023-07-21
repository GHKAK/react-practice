function Avatar({ size }) {
  return (
    <figure className="profile-avatar">
      <img
        src="./assets/images/avatar-1.jpg"
        alt="Elizabeth Foster"
        width={size}
        height={size}
      />
    </figure>
  );
}
export default Avatar;
