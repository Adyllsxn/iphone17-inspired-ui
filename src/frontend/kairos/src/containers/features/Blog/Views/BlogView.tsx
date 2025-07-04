import './BlogView.css';
import { FaRegCalendarAlt } from 'react-icons/fa';
import { Link } from 'react-router-dom';
import { motion } from 'framer-motion';

const blogPosts = [
  {
    img: "https://images.unsplash.com/photo-1500648767791-00dcc994a43e",
    date: "18 de abril de 2025",
    title: "Kairos: tecnologia e fé unidas para transformar a organização de cultos"
  },
  {
    img: "https://images.unsplash.com/photo-1521737604893-d14cc237f11d",
    date: "14 de abril de 2025",
    title: "Como o Kairos ajudou na organização do Culto Jovem de Páscoa 2025"
  },
  {
    img: "https://images.unsplash.com/photo-1584467735871-c24fc3f2768e",
    date: "10 de abril de 2025",
    title: "Conferência Kairos 2025: mais de 300 inscritos usando a plataforma"
  },
  {
    img: "https://images.unsplash.com/photo-1592194996308-7b43878e84a6",
    date: "4 de abril de 2025",
    title: "Gerencie seu perfil e receba notificações em tempo real com o Kairos"
  }
];

const BlogView = () => {
  return (
    <section className="blogViewSection">
      <div className="layoutContainer">
        <motion.h1 
          className="blogViewListTitle"
          initial={{ opacity: 0, y: -20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
        >
          Todos os Posts
        </motion.h1>

        <div className="blogListGrid">
          {blogPosts.map((post, index) => (
            <motion.div 
              className="blogCard" 
              key={index}
              initial={{ opacity: 0, y: 40 }}
              whileInView={{ opacity: 1, y: 0 }}
              viewport={{ once: true }}
              transition={{ duration: 0.5, delay: index * 0.1 }}
            >
              <div className="blogCardImageWrapper">
                <img src={post.img} alt={post.title} className="blogCardImage" />
              </div>
              <div className="blogCardContent">
                <span className="blogDate">
                  <FaRegCalendarAlt /> {post.date}
                </span>
                <h2 className="blogCardTitle">{post.title}</h2>
                <Link to="#" className="blogReadMore">Ler mais</Link>
              </div>
            </motion.div>
          ))}
        </div>
      </div>
    </section>
  );
};

export default BlogView;
