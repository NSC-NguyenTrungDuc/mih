package nta.med.service.common;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import java.util.zip.ZipOutputStream;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.mozilla.universalchardet.UniversalDetector;
import org.springframework.util.FileCopyUtils;

import au.com.bytecode.opencsv.CSVWriter;
import nta.med.data.model.ihis.system.DrugKinkiInterface;
import nta.med.data.model.ihis.system.ExportCsvInterface;

public class FileUtils {
	private static final Log LOGGER = LogFactory.getLog(FileUtils.class);

	public static boolean deleteDirectory(File directory) {
		if (directory.exists()) {
			File[] files = directory.listFiles();
			if (null != files) {
				for (int i = 0; i < files.length; i++) {
					if (files[i].isDirectory()) {
						deleteDirectory(files[i]);
					} else {
						files[i].delete();
					}
				}
			}
		}
		return (directory.delete());
	}
	public static void writeDataToZipFile(String zipFile, byte[] raw) throws IOException {

		Writer out = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(zipFile), "UTF8"));
		FileOutputStream fos = new FileOutputStream(zipFile);
		fos.write(raw);
		out.flush();
		out.close();
		fos.flush();
		fos.close();
		out.close();

	}


	public static void zipFile(List<String> srcFiles, String zipFile) {
		try {
			// create byte buffer
			byte[] buffer = new byte[1024];
			FileOutputStream fos = new FileOutputStream(zipFile);
			ZipOutputStream zos = new ZipOutputStream(fos);
			for (String scrFile : srcFiles) {
				File srcFile = new File(scrFile);
				FileInputStream fis = new FileInputStream(srcFile);
				// begin writing a new ZIP entry, positions the stream to the
				// start of the entry data
				zos.putNextEntry(new ZipEntry(srcFile.getName()));
				int length;
				while ((length = fis.read(buffer)) > 0) {
					zos.write(buffer, 0, length);
				}
				zos.closeEntry();
				// close the InputStream
				fis.close();
			}
			// close the ZipOutputStream
			zos.close();
		} catch (IOException e) {
			e.printStackTrace();
		}

	}
	public static void unZipFile(String zipFile, String outputFolder) {

		byte[] buffer = new byte[1024*20];
		File unZipFile = null;
		FileOutputStream fos = null;
		ZipInputStream zis = null;
		Writer out = null;

		try {
			FileInputStream inputStream = new FileInputStream(zipFile);
			zis = new ZipInputStream(inputStream);
			//get the zipped file list entry
			ZipEntry ze = zis.getNextEntry();
			while (ze != null) {
				unZipFile = new File(outputFolder);
				out = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(unZipFile), "UTF8"));
				fos = new FileOutputStream(unZipFile);
				int len;
				while ((len = zis.read(buffer)) > 0) {
					fos.write(buffer, 0, len);
				}
				ze = zis.getNextEntry();
			}
			inputStream.close();
		} catch (Exception e) {
			LOGGER.error("Error unZipFile " + e.getMessage());
		} finally {

			try {
				if (out != null) {
					out.flush();
					out.close();
				}

				if (zis != null) {
					zis.closeEntry();
					zis.close();

				}
				if (fos != null) {
					fos.flush();
					fos.close();
				}

				deleteFile(zipFile);

			} catch (IOException e) {
				LOGGER.error("Error unZipFile " + e.getMessage());
			}
		}
	}
	public static boolean deleteFile(String fileName) {
		try {
			File file = new File(fileName);
			if (!file.exists()) {
				System.out.println(file.getName() + " is not exist!!!");
				return false;
			}
			file.delete();
		} catch (Exception e) {
			LOGGER.error("Error in deleteFile" + e.getMessage());
			return false;
		}
		return true;
	}

	public static byte[] getKinkiMasterData(String directory, String fileName,
			String zipFile, List<DrugKinkiInterface> drugKinkiInterfaces, boolean shouldCreateCacheFile, String outputPath)
			throws IOException {

		File file = new File(directory);
		if (!file.exists())
			file.mkdirs();

		CSVWriter out = new CSVWriter(new OutputStreamWriter(
				new FileOutputStream(fileName), "UTF8"), ',');
		List<String[]> strings = new ArrayList<>();
		for (DrugKinkiInterface drugKinkiInterface : drugKinkiInterfaces) {
			strings.add(drugKinkiInterface.convertItemToArray());
		}
		out.writeAll(strings);
		out.flush();
		out.close();


		zipFile(Arrays.asList(fileName), zipFile);
		if(shouldCreateCacheFile && !StringUtils.isEmpty(outputPath))
		{  //move this file to cache
			File outputFile =  new File(outputPath);
			if(!outputFile.getParentFile().exists())
				outputFile.getParentFile().mkdirs();
			FileCopyUtils.copy(new File(zipFile), outputFile);
		}
		Path path = Paths.get(zipFile);
		byte[] datas = Files.readAllBytes(path);
		deleteDirectory(file);
		return datas;
	}
	
	public static String getKinkiMasterDataZipFile(String directory, String fileName, String zipFile, List<DrugKinkiInterface> drugKinkiInterfaces)
			throws IOException {

		File file = new File(directory);
		if (!file.exists())
			file.mkdirs();

		CSVWriter out = new CSVWriter(new OutputStreamWriter(
				new FileOutputStream(fileName), "UTF8"), ',');
		List<String[]> strings = new ArrayList<>();
		for (DrugKinkiInterface drugKinkiInterface : drugKinkiInterfaces) {
			strings.add(drugKinkiInterface.convertItemToArray());
		}
		out.writeAll(strings);
		out.flush();
		out.close();

		zipFile(Arrays.asList(fileName), zipFile);
		return zipFile;
	}
	
	public static byte[] getExportCsvData(String directory, String fileName, String fileZipPath,
			List<ExportCsvInterface>  exportData) throws IOException {
		File file = new File(directory);
		if (!file.exists())
			file.mkdirs();

		CSVWriter out = new CSVWriter(new OutputStreamWriter(
				new FileOutputStream(fileName), "UTF8"), ',');
		List<String[]> strings = new ArrayList<>();
		for (ExportCsvInterface data : exportData) {
			strings.add(data.convertItemToArray());
		}
		out.writeAll(strings);
		out.flush();
		out.close();
		zipFile(Arrays.asList(fileName), fileZipPath);
		Path path = Paths.get(fileZipPath);
		byte[] datas = Files.readAllBytes(path);
		deleteDirectory(file);
		return datas;
	}
	
	public static String encodingDetection(String unzipFileLoc) {
		UniversalDetector detector = null;
		try {
			detector = new UniversalDetector(null);
			Path path = Paths.get(unzipFileLoc);
			byte[] data = Files.readAllBytes(path);
			detector.handleData(data, 0, data.length);
			detector.dataEnd();
			String encoding = detector.getDetectedCharset();
			if (encoding != null) {
				return encoding;
			} else {
				LOGGER.warn("EncodingDetection cant detected");
				return "UTF8";
			}
		} catch (Exception e) {
			LOGGER.error("ERROR on encodingDetection" + e.getMessage());
			return "UTF8";
		} finally {
			if (detector != null) {
				detector.reset();
			}
		}
	}
	
//	public static byte[] getByteDataFile(String url, String hospCode, String token, String fileName, String kinkiType){
//    	byte[] raw = null;
//    	try {
//    		LOGGER.info("Starting download file: url = " + url + ", hosp_code = " + hospCode + ", token = " + token + ", file_name = " + fileName + ", kinky_type = " + kinkiType);
//    		
//    		Client client = ClientBuilder.newClient();//.register(json).register(xml);
//    		Response response = client
//            		.target(url)
//            		.request()
//                    .header("token", token)
//                    .header("filename", fileName)
//                    .header("HOSP_CODE", hospCode)
//                    .header("PATIENT_CODE", kinkiType)
//                    .get();
//    		
//    		//byte[] pdfByteArray = response.readEntity(ByteArray.class);
//    		InputStream is = response.readEntity(InputStream.class);
//    		raw = ByteStreams.toByteArray(is);
//		} catch (Exception e) {
//			LOGGER.error("Error on download file: " + e.getMessage());
//		}
//    	
//    	return raw;
//    }
	
	public static byte[] getByteDataFile(String filePath){
    	byte[] raw = null;
    	try {
    		Path path = Paths.get(filePath);
    		raw = Files.readAllBytes(path);
		} catch (Exception e) {
			LOGGER.error("Error on geiting file: Path = " + filePath + " , "+ e.getMessage());
		}
    	
    	return raw;
    }
	
	public static void copyFile(String sourcePath, String destPath){
		try {
			File source = new File(sourcePath);
			File dest = new File(destPath);
			if(dest.exists()){
				Files.delete(dest.toPath());
			}
			
			Files.copy(source.toPath(), dest.toPath());
		} catch (Exception e) {
			LOGGER.error("Error on copy file from " + sourcePath + " to " + destPath, e);
		}
	}
	
}
