package nta.sfd.core.misc.common;


import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

/**
 * The Utility class for read, write file, directory
 *
 * @author cuong.ta.van
 * @CrtDate Sep 05, 2014
 */
public class MedFileUtils extends org.apache.commons.io.FileUtils{

	private static final Logger LOG = LogManager.getLogger(MedFileUtils.class);
	
	/**
	 * Removes the.
	 *
	 * @param path the path
	 * @return true, if successful
	 */
	public static boolean remove(String path){	
		return remove(new File(path));
	}

	/**
	 * Removes the.
	 *
	 * @param f the f
	 * @return true, if successful
	 */
	public static boolean remove(File f){
		try {
			if(f.exists()){
				if(f.isFile()){
					return f.delete();
				}else{
					org.apache.commons.io.FileUtils.cleanDirectory(f);
				}
			}
			return true;
		} catch (IOException e) {
			return false;
		}
	}
	
	/**
	 * Creates the if not exist.
	 *
	 * @param path the path
	 * @return true, if successful
	 */
	public static boolean createIfNotExist(String path)	{
		return createIfNotExist(path, false);
	}
	
	/**
	 * Creates the if not exist.
	 *
	 * @param path the path
	 * @param isFile the is file
	 * @return true, if successful
	 */
	public static boolean createIfNotExist(String path, boolean isFile)	{	
		try {
			File f = new File(path);
			if(!f.exists()){
				if(isFile){
					createParentDirectory(path);
					if (!f.createNewFile()) {
						LOG.error("Cannot create file: " + path);
						return false;
					}
				}else{
					if (!f.mkdirs()) {
						LOG.error("Cannot create directory at: " + path);
						return false;
					}
				}
			}
			return true;
		} catch (IOException e) {
			LOG.error(e.getMessage());
		}
		return false;
	}
	
	/**
	 * Adds the file seperator.
	 *
	 * @param files the files
	 * @return the string
	 */
	public static String addFileSeperator(String...files){
		StringBuilder sb = new StringBuilder(files[0]);
		// files[0] has already appended to String builder
		for (int i = 1; i < files.length; i++) {
			sb.append(File.separator);
			sb.append(files[i]);
		}
		return sb.toString();
	}
	
	/**
	 * Gets the parent directory.
	 *
	 * @param path the path
	 * @return the parent directory
	 */
	public static String getParentDirectory(String path){
		File f = new File(path);
		return f.getParent();
	}
	
	/**
	 * Creates the parent directory.
	 *
	 * @param path the path
	 * @return true, if successful
	 */
	public static boolean createParentDirectory(String path){
		return createParentDirectory(path, true);
	}
	
	/**
	 * Creates the parent directory.
	 *
	 * @param path the path
	 * @param createIfNotExist the create if not exist
	 * @return true, if successful
	 */
	public static boolean createParentDirectory(String path, boolean createIfNotExist){
		String parent = getParentDirectory(path);	
		File f = new File(parent);
		if(!f.exists()){
			if (!f.mkdirs()) {
	        	LOG.error("Cannot create directory at: " + path);
	        	return false;
	        }
		}
		return true;
	}
	
	/**
	 * @author linh.nguyen.trong
	 * 
	 * Coppy file.
	 *
	 * @param srcFile the src file
	 * @param destDir the dest dir
	 * @return the file
	 */
	public static File coppyFile(File srcFile, String destDir) {
		File newDirectory = new File(destDir);
		try {
			if (!newDirectory.mkdir()) {
	        	LOG.error("Cannot create directory at: " + destDir);
	        }
			org.apache.commons.io.FileUtils.copyFileToDirectory(srcFile, newDirectory);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return newDirectory;
	}
	
	/**
	 * Save file.
	 *
	 * @param destDir the dest dir
	 * @param fileName the file name
	 * @param data the data
	 */
	public static File saveFile(String destDir, String fileName, String data) {
		try {
			LOG.debug("[start] destDir=" + destDir + ", fileName=" + fileName
					+ ",data=" + data);
			fileName = (destDir.endsWith(File.separator) ? destDir : destDir
					.concat(File.separator)) + fileName;
			File file = new File(fileName);
			if (!file.exists()) {
				if (!file.createNewFile()) {
		        	LOG.error("Cannot create file: " + destDir);
		        }
			}
//			FileWriter writer = new FileWriter(fileName);
//			writer.append(data);
//			writer.flush();
//			writer.close();
			OutputStream os = new FileOutputStream(fileName);
			PrintWriter w = new PrintWriter(new OutputStreamWriter(os, "UTF-8"));

		    w.print(data);
		    w.flush();
		    w.close();
			LOG.debug("[end] destDir=" + destDir + ", fileName=" + fileName);
			return file;
		} catch (Exception e) {
			LOG.error(e.getMessage(), e);
			return null;
		}
	}
}
