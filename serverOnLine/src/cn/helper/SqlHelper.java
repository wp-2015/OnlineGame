package cn.helper;

import java.io.IOException;
import java.io.InputStream;

import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;

import mapper.UserMapper;

public class SqlHelper {
	
	private SqlSessionFactory factory;
	
	public SqlHelper() throws IOException{
		String resource = "SqlMapConfig.xml";
		InputStream inputStream = Resources.getResourceAsStream(resource);
		factory = new SqlSessionFactoryBuilder().build(inputStream);
	}

	public <T> void insertById(Class<T> type, T t){
		SqlSession openSession = factory.openSession();
		
		T mapper = openSession.getMapper(type);
//		mapper.
		
	}
}
