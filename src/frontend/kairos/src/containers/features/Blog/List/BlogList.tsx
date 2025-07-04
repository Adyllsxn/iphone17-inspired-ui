import './BlogList.css';
import { FaRegCalendarAlt } from 'react-icons/fa';
import { Link } from 'react-router-dom';
import { motion } from 'framer-motion';

const BlogList = () => {
    return (
        <section className='blogSection'>
            <div className="layoutContainer blogContainer">
                <motion.h1 
                    className="blogTitle"
                    initial={{ opacity: 0, y: -30 }}
                    animate={{ opacity: 1, y: 0 }}
                    transition={{ duration: 0.6 }}
                >
                    Blog Kairos
                </motion.h1>

                <div className="blogGrid">
                    {/* Post em destaque */}
                    <motion.div
                        className="blogMainPost"
                        initial={{ opacity: 0, y: 40 }}
                        whileInView={{ opacity: 1, y: 0 }}
                        viewport={{ once: true }}
                        transition={{ duration: 0.8 }}
                    >
                        <div className="blogMainImageWrapper">
                            <img
                                src="https://images.unsplash.com/photo-1500648767791-00dcc994a43e"
                                alt="Kairos - Evento principal"
                                className="blogMainImage"
                            />
                        </div>
                        <div className="blogPostContent">
                            <span className="blogDate">
                                <FaRegCalendarAlt /> 18 de abril de 2025
                            </span>
                            <h2 className="blogPostTitle">
                                Kairos: tecnologia e fé unidas para transformar a organização de cultos
                            </h2>
                        </div>
                    </motion.div>

                    {/* Posts laterais */}
                    <div className="blogSidePosts">
                        {[{
                            img: "https://images.unsplash.com/photo-1521737604893-d14cc237f11d",
                            date: "14 de abril de 2025",
                            text: "Como o Kairos ajudou na organização do Culto Jovem de Páscoa 2025"
                        }, {
                            img: "https://images.unsplash.com/photo-1584467735871-c24fc3f2768e",
                            date: "10 de abril de 2025",
                            text: "Conferência Kairos 2025: mais de 300 inscritos usando a plataforma"
                        }, {
                            img: "https://images.unsplash.com/photo-1592194996308-7b43878e84a6",
                            date: "4 de abril de 2025",
                            text: "Gerencie seu perfil e receba notificações em tempo real com o Kairos"
                        }].map((post, index) => (
                            <motion.div
                                className="blogSidePost"
                                key={index}
                                initial={{ opacity: 0, x: 40 }}
                                whileInView={{ opacity: 1, x: 0 }}
                                viewport={{ once: true }}
                                transition={{ duration: 0.6, delay: index * 0.15 }}
                            >
                                <img src={post.img} alt="Post Kairos" />
                                <div>
                                    <span className="blogDate">
                                        <FaRegCalendarAlt /> {post.date}
                                    </span>
                                    <p>{post.text}</p>
                                </div>
                            </motion.div>
                        ))}
                    </div>
                </div>

                {/* Botão "Ver todos os posts" */}
                <motion.div
                    className="blogButtonWrapper"
                    initial={{ opacity: 0, scale: 0.8 }}
                    whileInView={{ opacity: 1, scale: 1 }}
                    viewport={{ once: true }}
                    transition={{ duration: 0.5 }}
                >
                    <button className="blogSeeMoreButton">
                        <Link to='/blogView'>Ver todos os posts</Link>
                    </button>
                </motion.div>
            </div>
        </section>
    );
};

export default BlogList;
