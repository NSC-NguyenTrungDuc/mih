package nta.med.ext.phr.caching;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.UnsupportedEncodingException;

import nta.med.ext.phr.model.UserInfo;
import redis.clients.jedis.Jedis;
import redis.clients.jedis.JedisPool;
import redis.clients.jedis.JedisPoolConfig;

/**
 * @author DEV-TiepNM
 */
public class ClusterTokenStore implements TokenManager<UserInfo> {

    private JedisPool pool;
    private Jedis jedis;
    private String host;
    private int port;
    private int timeout;
    private int expire;
    private JedisPoolConfig jedisPoolConfig;

    public void intConfig() {
        pool = new JedisPool(jedisPoolConfig, host, port, timeout);
        jedis = pool.getResource();

    }

    public void setHost(String host) {
        this.host = host;
    }

    public void setPort(int port) {
        this.port = port;
    }

    public void setTimeout(int timeout) {
        this.timeout = timeout;
    }

    public void setJedisPoolConfig(JedisPoolConfig jedisPoolConfig) {
        this.jedisPoolConfig = jedisPoolConfig;
    }

    public void setExpire(int expire) {
        this.expire = expire;
    }

    @Override
    public void put(String key, UserInfo value) {
        try {
            jedis.set(serializeKey(key), serializeValue(value));
            jedis.expire(serializeKey(key), expire);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public UserInfo get(String key) {
        try {
            return (UserInfo) deserialize(jedis.get(serializeKey(key)));
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public void invalidate(String key) {
        try {
            jedis.del(serializeKey(key));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public byte[] serializeValue(Object obj) throws IOException {
        ByteArrayOutputStream b = new ByteArrayOutputStream();
        ObjectOutputStream o = new ObjectOutputStream(b);
        o.writeObject(obj);
        return b.toByteArray();
    }

    public byte[] serializeKey(String string) throws UnsupportedEncodingException {
        return string == null ? null : string.getBytes("UTF-8");
    }

    public Object deserialize(byte[] bytes) throws IOException, ClassNotFoundException {
        if (bytes != null) {
            ByteArrayInputStream b = new ByteArrayInputStream(bytes);
            ObjectInputStream o = new ObjectInputStream(b);
            return o.readObject();
        }
        return null;

    }

}
