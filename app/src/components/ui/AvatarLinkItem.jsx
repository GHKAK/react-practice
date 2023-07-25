function AvatarLinkItem({name,uid}) {
  const avatarSrc=`./assets/images/${uid}.jpg`
  return (
    <li className="card-avatar-item">
      <a href="#">
        <img
          src={avatarSrc}
          alt={name}
          width={32}
          height={32}
        />
      </a>
    </li>
  );
}
export default AvatarLinkItem;
