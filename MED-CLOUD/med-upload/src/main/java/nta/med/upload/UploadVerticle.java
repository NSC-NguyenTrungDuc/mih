package nta.med.upload;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.channels.FileChannel;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import nta.med.core.glossary.SessionAttribute;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.SessionUserInfo;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.AsyncResult;
import org.vertx.java.core.AsyncResultHandler;
import org.vertx.java.core.Handler;
import org.vertx.java.core.VoidHandler;
import org.vertx.java.core.file.AsyncFile;
import org.vertx.java.core.http.HttpServer;
import org.vertx.java.core.http.HttpServerRequest;
import org.vertx.java.core.impl.VertxInternal;
import org.vertx.java.core.spi.cluster.ClusterManager;
import org.vertx.java.core.streams.Pump;
import org.vertx.java.platform.Verticle;

/**
 * @author dainguyen
 */
public class UploadVerticle extends Verticle {
	private static final Log logger = LogFactory.getLog(UploadVerticle.class);
	
	private Map clusterMap(String mapName){
        ClusterManager clusterManager = ((VertxInternal)vertx).clusterManager();
        Map map = clusterManager.getSyncMap(mapName);
        return map;
    }

	@Override
	public void start() {
		final Pattern uploadUrlPattern = Pattern.compile("/upload");
		final Pattern downloadUrlPattern = Pattern.compile("/download");
		final Pattern moveUrlPattern = Pattern.compile("/move");

		String hostname = UploadStartup.getConfigProperty("vertx.hostname", "127.0.0.1");
		Integer port = Integer.parseInt(UploadStartup.getConfigProperty("vertx.port", "8010"));
		final String uploadFolder = UploadStartup.getConfigProperty("upload.path", "/tmp");
		final String uploadTempFolder = UploadStartup.getConfigProperty("upload_temp.path", "/tmp1");
		HttpServer server = vertx.createHttpServer();
		
		HttpServer vpnServer = vertx.createHttpServer();
		Integer vpnPort = Integer.parseInt(UploadStartup.getConfigProperty("vertx.vpn.port", "8011"));
		String vpnHostname = UploadStartup.getConfigProperty("vertx.vpn.hostname", "127.0.0.1");

		initUploadDownLoad(server, uploadUrlPattern, moveUrlPattern, downloadUrlPattern, uploadFolder, uploadTempFolder, hostname, port);
		initUploadDownLoad(vpnServer, uploadUrlPattern, moveUrlPattern, downloadUrlPattern, uploadFolder, uploadTempFolder, vpnHostname, vpnPort);
		
	}
	
	private void initUploadDownLoad(HttpServer server, Pattern uploadUrlPattern, Pattern moveUrlPattern, Pattern downloadUrlPattern,
			String uploadFolder, String uploadTempFolder, String hostname, Integer port){
		server.requestHandler(new Handler<HttpServerRequest>() {
			@Override
			public void handle(final HttpServerRequest request) {
				final Matcher mUpload = uploadUrlPattern.matcher(request.path());
				final Matcher mMoveUpload = moveUrlPattern.matcher(request.path());
				final Matcher mDownload = downloadUrlPattern.matcher(request.path());
				logger.info("request of path: "+request.path());
				if (mUpload.matches()) {
					upload(request, uploadFolder, uploadTempFolder);
				} else if(mDownload.matches()){
					download(request, uploadFolder);
				}else if(mMoveUpload.matches()){
					move(request, uploadFolder, uploadTempFolder);
			    } else {
					request.response().setStatusCode(403).end();
					return;
				}
			}
		}).listen(port, hostname);
	}
	
	private void move(HttpServerRequest request, String uploadFolder, String uploadTempFolder){
		logger.info(request.headers());
		String token = request.headers().get("token");
		final String filename = request.headers().get("filename");
		final String hospCode = request.headers().get("HOSP_CODE");
		String patientCode = request.headers().get("PATIENT_CODE");
		final String type = request.headers().get("TRANSFER_TYPE");
		
		logger.info("Copy file " + filename + " with token: " + token);
        Map mapToken = clusterMap(token);
		//TODO: remove hardcode token
        if((token != null && token.equals("1234")) || !CollectionUtils.isEmpty(mapToken)) {
        	SessionUserInfo sessionInfo = (SessionUserInfo) mapToken.get(SessionAttribute.SESSION_USER_INFO.toString());
			if (isValidToken(token, sessionInfo, hospCode, patientCode)) {
	        	if(!StringUtils.isEmpty(type) && "1".equalsIgnoreCase(type)){
					patientCode = "PROTOCOL";
				}
	        	else if("2".equalsIgnoreCase(type)){
	        		patientCode = "NURIIMAGE";
	        	}
	        	
	        	String dir = uploadFolder.endsWith(File.separator) ? uploadFolder : uploadFolder + File.separator + hospCode;
	        	
	        	final String sourceFilePath = uploadTempFolder.endsWith(File.separator) ? uploadTempFolder : uploadTempFolder 
	        			+ File.separator + hospCode + File.separator + patientCode + File.separator + filename;
	        	
	        	logger.info(" copyFileFromTemp fileSourcePath: " + sourceFilePath);
	        	File destFolder = new File(dir);
	        	File destFile = null;
	        	File sourceFile = new File(sourceFilePath); 
	        	if (!sourceFile.exists()) {
	    			logger.info("Source File Not Found!" + sourceFile.getPath());
	    			request.response().setStatusCode(404).end();
	    			return;
	    		}
	    		/* if folder not exist then create one */
	    		if (!destFolder.exists()) {
	    			if (destFolder.mkdir()) {
						logger.info("FOLDER NOT EXIST, CREATE FOLDER FOR IMAGE:" + destFolder.getPath());
						destFolder = new File(dir + File.separator + patientCode);
						if(!destFolder.exists()){
							if (destFolder.mkdir()) {
								logger.info("FOLDER NOT EXIST, CREATE FOLDER FOR IMAGE:" + destFolder.getPath());
							} else {
								logger.info("CANNOT CREATE DIR " + dir + File.separator + patientCode);
								return;
							}
						}
					} else {
						logger.info("CANNOT CREATE DIR " + dir);
						return;
					}
	    		}else{
	    			destFolder = new File(dir + File.separator + patientCode);
					if (!destFolder.exists()) {
						if (destFolder.mkdir()) {
							logger.info("FOLDER NOT EXIST, CREATE FOLDER FOR IMAGE:" + destFolder.getPath());
						} else {
							logger.info("CANNOT CREATE DIR " + dir + File.separator + patientCode);
							return;
						}
					}
	    		}
	    		/* file not exist then create one */
	    		try {
					destFile = new File(destFolder + File.separator + filename); 
					destFile.createNewFile();
					logger.info("FILE NOT EXIST, CREATE FILE INSIDE FOLDER:" + destFile.getPath());
				} catch (IOException e) {
					logger.info("CANT CREATE FILE:" + destFile.getPath());
					return;
				}
	    		/* copy file from source to dest */
	    		if (destFile != null && sourceFile != null){
	    			moveFile(sourceFile, destFile);
	    			logger.info("COPY DONE FROM SOURCE FILE " + sourceFilePath + " TO DEST FILE " + destFile.getPath());
	    		}
	        } else {
	        	request.response().setStatusCode(403).end();
	        }
        } else {
        	request.response().setStatusCode(403).end();
        }	
	}
	@SuppressWarnings("resource")
	private void moveFile(File sourceFile, File destFile){
		FileChannel source = null;
		FileChannel destination = null;
		try {
			/**
			 * getChannel() returns unique FileChannel object associated a file
			 * output stream.
			 */
			source = new FileInputStream(sourceFile).getChannel();

			destination = new FileOutputStream(destFile).getChannel();

			if (destination != null && source != null) {
				destination.transferFrom(source, 0, source.size());
			}

		} catch (FileNotFoundException e) {
			logger.info("moveFile FileNotFoundException " + e.getMessage());
			e.printStackTrace();
		} catch (IOException e) {
			logger.info("moveFile IOException " + e.getMessage());
			e.printStackTrace();
		}
		finally {
			if (source != null) {
				try {
					source.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
			if (destination != null) {
				try {
					destination.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}
	}
	private void download (HttpServerRequest request, String uploadFolder){
		logger.info(request.headers());
        String token = request.headers().get("token");
        final String filename = request.headers().get("filename");
        final String hospCode = request.headers().get("HOSP_CODE");
        String patientCode = request.headers().get("PATIENT_CODE");        
        final String type = request.headers().get("TRANSFER_TYPE");
        
        logger.info("Downloading file " + filename + " with token: " + token);
        Map mapToken = clusterMap(token);
		//TODO: remove hardcode token
        if((token != null && token.equals("1234")) || !CollectionUtils.isEmpty(mapToken)) {
        	SessionUserInfo sessionInfo = (SessionUserInfo) mapToken.get(SessionAttribute.SESSION_USER_INFO.toString());
			if (isValidToken(token, sessionInfo, hospCode, patientCode)) {
	        	if(!StringUtils.isEmpty(type) && "1".equalsIgnoreCase(type)){
					patientCode = "PROTOCOL";
				}
	        	else if("2".equalsIgnoreCase(type)){
	        		patientCode = "NURIIMAGE";
	        	}
	        	
	        	final String filePath = uploadFolder.endsWith(File.separator) ? uploadFolder : uploadFolder 
	        			+ File.separator + hospCode +  File.separator + patientCode + File.separator + filename;
	        	logger.info("Path: " + filePath);
	        	File file = new File(filePath); 
	        	if (!file.exists()) {
	        		logger.info("ERROR - File not exist in path: " + filePath);
	        		request.response().setStatusCode(404).end();
	        		return;
	        	}
        	
	        	request.pause();
	        	request.response().sendFile(filePath);
	        	request.resume();
	        } else {
	        	request.response().setStatusCode(403).end();
	        }
        } else {
        	request.response().setStatusCode(403).end();
        }
	}
	private boolean isValidToken(String token, SessionUserInfo sessionInfo, String hospCode, String patientCode)
	{
		return token != null && (token.equals("1234") || (sessionInfo.getHospitalCode().equals(hospCode)))
				&& !StringUtils.isEmpty(hospCode)
				&& !StringUtils.isEmpty(patientCode);
	}
	private void upload (HttpServerRequest request, String uploadFolder, String uploadTempFolder){
		logger.info(request.headers());
		String token = request.headers().get("token");
		final String filename = request.headers().get("filename");
		final String hospCode = request.headers().get("HOSP_CODE");
		String patientCode = request.headers().get("PATIENT_CODE");
		final String type = request.headers().get("TRANSFER_TYPE");
		final String isTemp = request.headers().get("TEMP");
		
		logger.info("uploading file " + filename + " with token: " + token);

		Map mapToken = clusterMap(token);
		//TODO: remove hardcode token
        if((token != null && token.equals("1234")) || !CollectionUtils.isEmpty(mapToken)) {
        	SessionUserInfo sessionInfo = (SessionUserInfo) mapToken.get(SessionAttribute.SESSION_USER_INFO.toString());
	        if (isValidToken(token, sessionInfo, hospCode, patientCode)) {
	        	if(!StringUtils.isEmpty(type) && "1".equalsIgnoreCase(type)){
					patientCode = "PROTOCOL";
				}
	        	else if("2".equalsIgnoreCase(type)){
	        		patientCode = "NURIIMAGE";
	        	}
	        	
	        	logger.info("isTemp: " + isTemp);
				String filePath ;
				String dir ;
				if(YesNo.YES.getValue().equals(isTemp)){
					filePath = uploadTempFolder.endsWith(File.separator) ? uploadTempFolder : uploadTempFolder 
							+ File.separator + hospCode + File.separator + patientCode + File.separator + filename;
					dir = uploadTempFolder.endsWith(File.separator) ? uploadTempFolder : uploadTempFolder + File.separator + hospCode + File.separator;
				}else {
					filePath = uploadFolder.endsWith(File.separator) ? uploadFolder : uploadFolder 
							+ File.separator + hospCode + File.separator + patientCode + File.separator + filename;
					dir = uploadFolder.endsWith(File.separator) ? uploadFolder : uploadFolder + File.separator + hospCode;
				}
				logger.info("Path: " + filePath);
				logger.info("dir path: " + dir);
				
				File file = new File(dir);
				if (!file.exists()) {
					if (file.mkdir()) {
						logger.info("FILE NOT EXIST, CREATE FOLDER FOR IMAGE:" + file.getPath());
						file = new File(dir + File.separator + patientCode);
						if (file.mkdir()) {
							logger.info("FILE NOT EXIST, CREATE FOLDER FOR IMAGE:" + file.getPath());
						} else {
							logger.info("CANNOT CREATE DIR " + dir + File.separator + patientCode);
							return;
						}
					} else {
						logger.info("CANNOT CREATE DIR " + dir);
						return;
					}
				} else {
					file = new File(dir + File.separator + patientCode);
					if (!file.exists()) {
						if (file.mkdir()) {
							logger.info("FILE NOT EXIST, CREATE FOLDER FOR IMAGE:" + file.getPath());
						} else {
							logger.info("CANNOT CREATE DIR " + dir + File.separator + patientCode);
							return;
						}
					}
				}
				// We first pause the request so we don't receive any data
				// between now and when the file is opened
				request.pause();
				vertx.fileSystem().open(filePath, new AsyncResultHandler<AsyncFile>() {
					public void handle(AsyncResult<AsyncFile> ar) {
						if (ar.failed()) {
							logger.error(ar.cause().getStackTrace());
							return;
						}
						final AsyncFile file = ar.result();
						final Pump pump = Pump.createPump(request, file);
						final long start = System.currentTimeMillis();
						request.endHandler(new VoidHandler() {
							public void handle() {
								file.close(new AsyncResultHandler<Void>() {
									public void handle( AsyncResult<Void> ar) {
										if (ar.succeeded()) {
											request.response().setStatusCode(200).end();
											long end = System.currentTimeMillis();
											logger.info("Uploaded " + pump.bytesPumped() + " bytes to " + filename + " in " + (end - start) + " ms");
										} else {
											request.response().setStatusCode(500).end();
											logger.error(ar.cause().getStackTrace());
										}
									}
								});
							}
						});
						pump.start();
						request.resume();
					}
				});
	        } else {
	        	request.response().setStatusCode(403).end();
	        }
        } else {
        	request.response().setStatusCode(403).end();
        }
	}
}
