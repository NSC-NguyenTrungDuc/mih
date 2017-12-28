package nta.med.service.ihis.handler.bass;

import au.com.bytecode.opencsv.CSVReader;
import com.google.protobuf.ByteString;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.kinki.*;
import nta.med.core.glossary.KinkiCsvLength;
import nta.med.core.glossary.KinkiExportCsvName;
import nta.med.core.glossary.KinkiTable;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.BaseRepository;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.kinki.*;
import nta.med.data.model.ihis.system.*;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.common.FileUtils;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS2015U00MasterDataRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS2015U00MasterDataResponse;
import nta.med.service.ihis.proto.CommonModelProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.io.*;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.*;

/**
 * @author DEV-TiepNM
 */

@Service
@Scope("prototype")
@Transactional
public class BAS2015U00MasterDataHandler extends ScreenHandler<BassServiceProto.BAS2015U00MasterDataRequest, BassServiceProto.BAS2015U00MasterDataResponse> {

	@Resource
	private BaseRepository baseRepository;
	@Resource
	private DrugDosageRepository drugDosageRepository;
	@Resource
	private DrugGenericNameRepository drugGenericNameRepository;
	@Resource
	private DrugKinkiMessageRepository drugKinkiMessageRepository;
	@Resource
	private DrugKinkiDiseaseRepository drugKinkiDiseaseRepository;
	@Resource
	private DrugDosageStandardRepository drugDosageStandardRepository;
	@Resource
	private DrugDosageNormalRepository drugDosageNormalRepository;
	@Resource
	private DrugDosageAddtionRepository drugDosageAddtionRepository;
	@Resource
	private DrugCheckingRepository drugCheckingRepository;
	@Resource
	private DrugInteractionRepository drugInteractionRepository;
	@Resource
	private RevisionRepository revisionRepository;
	@Resource
	private CommonRepository commonRepository;
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	 private static Properties properties = new Properties();
	    private static final Log LOGGER = LogFactory.getLog(BAS2015U00MasterDataHandler.class);

	    static {
	        InputStream is = null;
	        try {
	            String configPath = System.getProperty("configPath");
	            File file = new File((configPath == null ? "" : configPath + "/") + "configs.properties");
	            is = new FileInputStream(file);
	            properties.load(is);
	        } catch (Exception ignore) {
	            LOGGER.error(ignore.getMessage(), ignore);
	        } finally {
	            if (is != null) {
	                try {
	                    is.close();
	                } catch (IOException e) {
	                    LOGGER.error(e.getMessage(), e);
	                }
	            }
	        }
	    }

	    public static String getConfigProperty(String name, String defaultValue) {
	        return properties.getProperty(name, defaultValue);
	    }
	
    @SuppressWarnings("finally")
	@Override
	@Route(global = true)
    public BAS2015U00MasterDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, BAS2015U00MasterDataRequest request) throws Exception {
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
		Long timeStamp = Calendar.getInstance().getTime().getTime();
    	String directoryImport = getConfigProperty("cache.path", "D:\\");
    	List<String> tableNames = new ArrayList<>();


    	String zipFileLoc;
    	String unZipFileLoc;
    	try {
    		CommonModelProto.KinkiType kinkiType = request.getKinkiType();
    		CommonModelProto.ActionType actionType = request.getActionType();
    		String userId = request.getUserId();
    		byte[] raw = request.getData().toByteArray();
			String directory = getConfigProperty("cache.path", "D:\\") + File.separator + "latest"+ File.separator + timeStamp + File.separator;
			File file = new File(directory);
			if(!file.exists()) file.mkdirs();

			String latestCacheFile = "";
			if(CommonModelProto.ActionType.IMPORT.equals(actionType)){
				if (CommonModelProto.KinkiType.KINKI_MSG.equals(kinkiType)) {
					tableNames.add(KinkiTable.DRUG_KINKI_MESSAGE.toString());
					commonRepository.deleteTable(KinkiTable.DRUG_KINKI_MESSAGE.toString());
					zipFileLoc = directoryImport + CommonModelProto.KinkiType.KINKI_MSG.toString() + timeStamp + ".zip";
					FileUtils.writeDataToZipFile(zipFileLoc, raw);
					//upzip file
					unZipFileLoc = directoryImport + CommonModelProto.KinkiType.KINKI_MSG.toString() + timeStamp + ".csv"; 
					FileUtils.unZipFile(zipFileLoc, unZipFileLoc);
	        		response = insertDrgKinkiMessage(unZipFileLoc, userId);
					latestCacheFile = directory + CommonModelProto.KinkiType.KINKI_MSG.toString() + ".zip";

				 } else if (CommonModelProto.KinkiType.KINKI_DIEASE.equals(kinkiType)) {
					tableNames.add(KinkiTable.DRUG_KINKI_DISEASE.toString());
					commonRepository.deleteTable(KinkiTable.DRUG_KINKI_DISEASE.toString());
					zipFileLoc = directoryImport + CommonModelProto.KinkiType.KINKI_DIEASE.toString() + timeStamp + ".zip";
					FileUtils.writeDataToZipFile(zipFileLoc, raw);
					//upzip file
					unZipFileLoc = directoryImport + CommonModelProto.KinkiType.KINKI_DIEASE.toString() + timeStamp + ".csv";
					FileUtils.unZipFile(zipFileLoc, unZipFileLoc);
		        	response = insertKinkiDisease(unZipFileLoc, userId);
					latestCacheFile = directory + CommonModelProto.KinkiType.KINKI_DIEASE.toString() + ".zip";
				 } else if (CommonModelProto.KinkiType.DOSAGE.equals(kinkiType)) {
					tableNames.add(KinkiTable.DRUG_DOSAGE.toString());
					commonRepository.deleteTable(KinkiTable.DRUG_DOSAGE.toString());
					commonRepository.deleteTable(KinkiTable.DRUG_DOSAGE_ADDITION.toString());
					commonRepository.deleteTable(KinkiTable.DRUG_DOSAGE_NORMAL.toString());
					commonRepository.deleteTable(KinkiTable.DRUG_DOSAGE_STANDARD.toString());
					zipFileLoc = directoryImport + CommonModelProto.KinkiType.DOSAGE.toString() + timeStamp + ".zip";
					FileUtils.writeDataToZipFile(zipFileLoc, raw);
					//upzip file
					unZipFileLoc = directoryImport + CommonModelProto.KinkiType.DOSAGE.toString() + timeStamp + ".csv";
					FileUtils.unZipFile(zipFileLoc, unZipFileLoc);
		        	response = insertKinkiDosage(unZipFileLoc, userId, getLanguage(vertx, sessionId));
					latestCacheFile = directory + CommonModelProto.KinkiType.DOSAGE.toString() + ".zip";
					
				 } else if (CommonModelProto.KinkiType.DRUG_CHECKING.equals(kinkiType)) {
					tableNames.add(KinkiTable.DRUG_CHECKING.toString());
					commonRepository.deleteTable(KinkiTable.DRUG_CHECKING.toString());
					zipFileLoc = directoryImport + CommonModelProto.KinkiType.DRUG_CHECKING.toString() + timeStamp + ".zip";
					FileUtils.writeDataToZipFile(zipFileLoc, raw);
					//upzip file
					unZipFileLoc = directoryImport + CommonModelProto.KinkiType.DRUG_CHECKING.toString() + timeStamp + ".csv";
					FileUtils.unZipFile(zipFileLoc, unZipFileLoc);
				    response = insertDrugChecking(unZipFileLoc, userId);
					latestCacheFile = directory + CommonModelProto.KinkiType.DRUG_CHECKING.toString() + ".zip";
				 } else if (CommonModelProto.KinkiType.INTERATION.equals(kinkiType)) {
					tableNames.add(KinkiTable.DRUG_INTERACTION.toString());
					commonRepository.deleteTable(KinkiTable.DRUG_INTERACTION.toString());
					zipFileLoc = directoryImport + CommonModelProto.KinkiType.INTERATION.toString() + timeStamp + ".zip";
					FileUtils.writeDataToZipFile(zipFileLoc, raw);
					//upzip file
					unZipFileLoc = directoryImport + CommonModelProto.KinkiType.INTERATION.toString() + timeStamp + ".csv";
					FileUtils.unZipFile(zipFileLoc, unZipFileLoc);
			        response = insertDrgInteraction(unZipFileLoc, userId);
					latestCacheFile = directory + CommonModelProto.KinkiType.INTERATION.toString() + ".zip";
				 } else if (CommonModelProto.KinkiType.GENERIC_NAME.equals(kinkiType)) {
					tableNames.add(KinkiTable.DRUG_GENERIC_NAME.toString());
					commonRepository.deleteTable(KinkiTable.DRUG_GENERIC_NAME.toString());
					zipFileLoc = directoryImport + CommonModelProto.KinkiType.GENERIC_NAME.toString() + timeStamp + ".zip";
					FileUtils.writeDataToZipFile(zipFileLoc, raw);
					//upzip file
					unZipFileLoc = directoryImport + CommonModelProto.KinkiType.GENERIC_NAME.toString() + timeStamp + ".csv";
					FileUtils.unZipFile(zipFileLoc, unZipFileLoc);
				    response = insertGenericName(unZipFileLoc, userId);
					latestCacheFile = directory + CommonModelProto.KinkiType.GENERIC_NAME.toString() + ".zip";
				 }

				//Update Revision
				if(!StringUtils.isEmpty(latestCacheFile)){
					revisionRepository.updateRevisionByTableName(tableNames, new Date(), latestCacheFile);
				}

			} else if(CommonModelProto.ActionType.EXPORT.equals(actionType)){
				
				 directory = getConfigProperty("cache.path", "D:\\") + timeStamp + File.separator;
	        	if (CommonModelProto.KinkiType.KINKI_MSG.equals(kinkiType)) {
	        		response = exportMsgToByteStringData(directory);
	            } else if (CommonModelProto.KinkiType.KINKI_DIEASE.equals(kinkiType)) {
	            	response = exportDieaseToByteStringData(directory);
	            } else if (CommonModelProto.KinkiType.DOSAGE.equals(kinkiType)) {
	            	response = exportDosageToByteStringData(directory);
	            } else if (CommonModelProto.KinkiType.DRUG_CHECKING.equals(kinkiType)) {
	            	response = exportDrugCheckingToByteStringData(directory,  getLanguage(vertx, sessionId));
	            } else if (CommonModelProto.KinkiType.INTERATION.equals(kinkiType)) {
	            	response = exportInterationToByteStringData(directory, getLanguage(vertx, sessionId));
	            } else if (CommonModelProto.KinkiType.GENERIC_NAME.equals(kinkiType)) {
	            	response = exportGenericToByteStringData(directory, getLanguage(vertx, sessionId));
	            }
			} else {
				response.setKinkiType(request.getKinkiType());
				response.setResult(false);
				LOGGER.error("BAS2015U00MasterDataHandler NOT FOUND 'actionType' : actionType = " + request.getActionType());
			}
		} catch (Exception e) {
			LOGGER.error("BAS2015U00MasterDataHandler handle" + e.getMessage());
			throw new ExecutionException(response.build());
		}finally{

			return response.build();
		}
    }
    
	public BassServiceProto.BAS2015U00MasterDataResponse.Builder insertDrgKinkiMessage(String fileName, String sysId) throws IOException{
		BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
		String msg = null;
		try (CSVReader csvReader = new CSVReader(new InputStreamReader(new FileInputStream(fileName), FileUtils.encodingDetection(fileName)))) {
			List<DrugKinkiMessage> drugKinkiMessages = new ArrayList<>();
			String[] nextline;
			Integer lineNumber = 0;
			while ((nextline = csvReader.readNext()) != null) {
				++lineNumber;
				if (nextline.length > KinkiCsvLength.DRUG_KINKI_MESSAGE.getValue()) {
					DrugKinkiMessage drugKinkiMessage = new DrugKinkiMessage();
					Date date = new Date();
					drugKinkiMessage.setSysId(sysId);
					drugKinkiMessage.setCreated(new Timestamp(date.getTime()));
					drugKinkiMessage.setActiveFlg(new BigDecimal(1));
					drugKinkiMessage.setDrugId(nextline[0]);
					drugKinkiMessage.setBranchNumber(nextline[1]);
					drugKinkiMessage.setWarningLevel(new BigDecimal(nextline[2].trim()));
					drugKinkiMessage.setKinkiId(nextline[3]);
					drugKinkiMessage.setMessage(nextline[4]);
					drugKinkiMessage.setCategory(nextline[5]);
					drugKinkiMessages.add(drugKinkiMessage);
				} else {
					msg = String.valueOf(lineNumber);
				}
			}
			baseRepository.saveObjects(drugKinkiMessages);

			response.setKinkiType(CommonModelProto.KinkiType.KINKI_MSG);
			response.setResult(true);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			return response;
		} catch (Exception e) {
			LOGGER.error("BAS2015U00MasterDataHandler error CsvFileReader in insertDrgKinkiMessage" + e.getMessage());
			response.setKinkiType(CommonModelProto.KinkiType.KINKI_MSG);
			response.setResult(false);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			throw new ExecutionException(response.build());
		} finally {
			FileUtils.deleteFile(fileName);
		}
    }
    
	public BassServiceProto.BAS2015U00MasterDataResponse.Builder insertKinkiDisease(String fileName, String sysId) throws IOException{
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
		String msg = null;
		try (CSVReader csvReader = new CSVReader(new InputStreamReader(new FileInputStream(fileName), FileUtils.encodingDetection(fileName)))) {
			List<DrugKinkiDisease> drugKinkiDiseases = new ArrayList<>();
			String[] nextline;
			Integer lineNumber = 0;
			while ((nextline = csvReader.readNext()) != null) {
				++lineNumber;
				if (nextline.length > KinkiCsvLength.DRUG_KINKI_DISEASE.getValue()) {
					DrugKinkiDisease drugKinkiDisease = new DrugKinkiDisease();
					Date date = new Date();
					drugKinkiDisease.setSysId(sysId);
					drugKinkiDisease.setCreated(new Timestamp(date.getTime()));
					drugKinkiDisease.setActiveFlg(new BigDecimal(1));
					drugKinkiDisease.setKinkiId(nextline[0]);
					drugKinkiDisease.setDiseaseName(nextline[1]);
					drugKinkiDisease.setIndexTerm(nextline[2]);
					drugKinkiDisease.setStandardDiseaseName(nextline[3]);
					drugKinkiDisease.setDiseaseCode(nextline[4]);
					drugKinkiDisease.setIcd10(nextline[5]);
					drugKinkiDisease.setDecisionFlg(new BigDecimal(nextline[6].trim()));
					drugKinkiDisease.setComment(nextline[7]);
					drugKinkiDiseases.add(drugKinkiDisease);
				} else {
					msg = String.valueOf(lineNumber);
				}
			}
			baseRepository.saveObjects(drugKinkiDiseases);

			response.setKinkiType(CommonModelProto.KinkiType.KINKI_DIEASE);
			response.setResult(true);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			return response;
		} catch (Exception e) {
			LOGGER.error("BAS2015U00MasterDataHandler error CsvFileReader in insertKinkiDisease" + e.getMessage());
			response.setKinkiType(CommonModelProto.KinkiType.KINKI_DIEASE);
			response.setResult(false);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			throw new ExecutionException(response.build());
		} finally {
			FileUtils.deleteFile(fileName);
		}
    }
    
   	public BassServiceProto.BAS2015U00MasterDataResponse.Builder insertDrgInteraction(String fileName, String sysId) throws IOException{
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
		String msg = null;
		try (CSVReader csvReader = new CSVReader(new InputStreamReader(new FileInputStream(fileName), FileUtils.encodingDetection(fileName)))) {
			List<DrugInteraction> drugInteractions = new ArrayList<>();
			Integer lineNumber = 0;
			String[] nextline;
			while ((nextline = csvReader.readNext()) != null) {
				++lineNumber;
				if (nextline.length > KinkiCsvLength.DRUG_INTERACTION.getValue()) {
					DrugInteraction drugInteraction = new DrugInteraction();
					Date date = new Date();
					drugInteraction.setSysId(sysId);
					drugInteraction.setCreated(new Timestamp(date.getTime()));
					drugInteraction.setActiveFlg(new BigDecimal(1));
					drugInteraction.setDrugId(nextline[0]);
					drugInteraction.setBranchNumber(nextline[1]);
					drugInteraction.setYj9Code(nextline[2]);
					drugInteraction.setDescribedClassification(CommonUtils.parseInteger(nextline[3].trim()));
					drugInteraction.setA5(nextline[4]);
					drugInteraction.setA6(nextline[5]);
					drugInteraction.setA7(CommonUtils.parseInteger(nextline[6].trim()));
					drugInteraction.setA8(CommonUtils.parseInteger(nextline[7].trim()));
					drugInteraction.setA9(CommonUtils.parseInteger(nextline[8].trim()));
					drugInteraction.setOrderNote(CommonUtils.parseInteger(nextline[9].trim()));
					drugInteraction.setA11(CommonUtils.parseInteger(nextline[10].trim()));
					drugInteraction.setComment(nextline[11]);
					drugInteractions.add(drugInteraction);
				} else {
					msg = String.valueOf(lineNumber);
				}
			}
			baseRepository.saveObjects(drugInteractions);

			response.setKinkiType(CommonModelProto.KinkiType.INTERATION);
			response.setResult(true);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			return response;
		} catch (Exception e) {
			LOGGER.error("BAS2015U00MasterDataHandler error CsvFileReader in insertDrgInteraction" + e.getMessage());
			response.setKinkiType(CommonModelProto.KinkiType.INTERATION);
			response.setResult(false);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			throw new ExecutionException(response.build());
		} finally {
			FileUtils.deleteFile(fileName);
		}
    }
    
   	public BassServiceProto.BAS2015U00MasterDataResponse.Builder insertGenericName(String fileName, String sysId) throws IOException{
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
		String msg = null;
		try (CSVReader csvReader = new CSVReader(new InputStreamReader(new FileInputStream(fileName), FileUtils.encodingDetection(fileName)))) {
			List<DrugGenericName> drugGenericNames = new ArrayList<>();
			Integer lineNumber = 0;
			String[] nextline;
			while ((nextline = csvReader.readNext()) != null) {
				++lineNumber;
				if (nextline.length > KinkiCsvLength.DRUG_GENERIC_NAME.getValue()) {
					DrugGenericName drugGenericName = new DrugGenericName();
					Date date = new Date();
					drugGenericName.setSysId(sysId);
					drugGenericName.setCreated(new Timestamp(date.getTime()));
					drugGenericName.setActiveFlg(new BigDecimal(1));
					drugGenericName.setDrugId(nextline[0]);
					drugGenericName.setBranchNumber(nextline[1]);
					drugGenericName.setYj9Code(nextline[2]);
					drugGenericName.setDescribedClassification(CommonUtils.parseInteger(nextline[3].trim()));
					drugGenericName.setOrderNote(CommonUtils.parseInteger(nextline[4].trim()));
					drugGenericName.setA6(nextline[5]);
					drugGenericName.setYj9CodeEffect(nextline[6]);
					drugGenericName.setA8(CommonUtils.parseInteger(nextline[7].trim()));
					drugGenericName.setComment1(nextline[8]);
					drugGenericName.setComment2(nextline[9]);
					drugGenericNames.add(drugGenericName);
				} else {
					msg = String.valueOf(lineNumber);
				}
			}
			baseRepository.saveObjects(drugGenericNames);

			response.setKinkiType(CommonModelProto.KinkiType.GENERIC_NAME);
			response.setResult(true);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			return response;
		} catch (IOException e) {
			LOGGER.error("BAS2015U00MasterDataHandler error CsvFileReader in insertGenericName" + e.getMessage());
			response.setKinkiType(CommonModelProto.KinkiType.GENERIC_NAME);
			response.setResult(false);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			throw new ExecutionException(response.build());
		} finally {
			FileUtils.deleteFile(fileName);
		}
	}
    
   	public BassServiceProto.BAS2015U00MasterDataResponse.Builder insertDrugChecking(String fileName, String sysId) throws IOException {
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
		String msg = null;
		try (CSVReader csvReader = new CSVReader(new InputStreamReader(new FileInputStream(fileName), FileUtils.encodingDetection(fileName)))) {
			List<DrugChecking> drugCheckings = new ArrayList<>();
			Integer lineNumber = 0;
			String[] nextline;
			
			csvReader.readNext();	// ignore header line
			while ((nextline = csvReader.readNext()) != null) {
				++lineNumber;
				if (nextline.length > KinkiCsvLength.DRUG_CHECKING.getValue()) {
					DrugChecking drugChecking = new DrugChecking();
					Date date = new Date();
					drugChecking.setSysId(sysId);
					drugChecking.setCreated(new Timestamp(date.getTime()));
					drugChecking.setActiveFlg(new BigDecimal(1));
					drugChecking.setDrugId(nextline[0]);
					drugChecking.setBranchNumber(nextline[1]);
					drugChecking.setA3(nextline[2]);
					drugChecking.setA4(nextline[3]);
					drugChecking.setA5(nextline[4]);
					drugChecking.setA6(nextline[5]);
					drugChecking.setA7(nextline[6]);
					drugChecking.setA8(nextline[7]);
					drugChecking.setA9(nextline[8]);
					drugChecking.setYjCode(nextline[9]);
					drugChecking.setA11(nextline[10]);
					drugChecking.setA12(nextline[11]);
					drugChecking.setA13(nextline[12]);
					drugChecking.setA14(nextline[13]);
					drugChecking.setA15(nextline[14]);
					drugChecking.setA16(nextline[15]);
					drugChecking.setA17(nextline[16]);
					drugChecking.setA18(nextline[17]);
					drugChecking.setA19(CommonUtils.parseInteger(nextline[18].trim()));
					drugChecking.setA20(nextline[19]);
					drugChecking.setA21(CommonUtils.parseInteger(nextline[20].trim()));
					drugChecking.setA22(CommonUtils.parseInteger(nextline[21].trim()));
					drugChecking.setA23(nextline[22]);
					drugChecking.setA24(nextline[23]);
					drugChecking.setA25(DateUtil.toDate(nextline[24].trim(), DateUtil.PATTERN_YYMMDD));
					drugChecking.setA26(DateUtil.toDate(nextline[25].trim(), DateUtil.PATTERN_YYMMDD));
					drugChecking.setA27(DateUtil.toDate(nextline[26].trim(), DateUtil.PATTERN_YYMMDD));
					drugChecking.setA28(DateUtil.toDate(nextline[27].trim(), DateUtil.PATTERN_YYMMDD));
					drugCheckings.add(drugChecking);
				} else {
					msg = String.valueOf(lineNumber);
				}
			}
			baseRepository.saveObjects(drugCheckings);
			response.setKinkiType(CommonModelProto.KinkiType.DRUG_CHECKING);
			response.setResult(true);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			return response;
		} catch (Exception e) {
			LOGGER.error("BAS2015U00MasterDataHandler error CsvFileReader in insertDrugChecking" + e.getMessage());
			response.setKinkiType(CommonModelProto.KinkiType.DRUG_CHECKING);
			response.setResult(false);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			throw new ExecutionException(response.build());
		} finally {
			FileUtils.deleteFile(fileName);
		}
    }
    
  //export data
    private BassServiceProto.BAS2015U00MasterDataResponse.Builder exportMsgToByteStringData(String directory) throws IOException {
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
    	 String fileName = directory + KinkiExportCsvName.DRUG_KINKI_MESSAGE.getValue() + ".csv";
         String zipFile = directory + KinkiExportCsvName.DRUG_KINKI_MESSAGE.getValue()  + ".zip";

         List<DrugKinkiMessageInfo> drugKinkiDiseaseInfos =  drugKinkiMessageRepository.getDrugKinkiMessageInfo();
         List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
         for (DrugKinkiMessageInfo drugKinkiDiseaseInfo : drugKinkiDiseaseInfos) {
             drugKinkiInterfaces.add(drugKinkiDiseaseInfo);
         }
         response.setResult(Boolean.TRUE);
         response.setKinkiType(CommonModelProto.KinkiType.KINKI_MSG);
        response.setData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugKinkiInterfaces,  false, "")));
        return response;
    } 
    
    private BassServiceProto.BAS2015U00MasterDataResponse.Builder exportDieaseToByteStringData(String directory) throws IOException {
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
    	String fileName = directory + KinkiExportCsvName.DRUG_KINKI_DISEASE.getValue()  + ".csv";
        String zipFile = directory + KinkiExportCsvName.DRUG_KINKI_DISEASE.getValue()  + ".zip";

        List<DrugKinkiDiseaseInfo> drugKinkiDiseaseInfos =  drugKinkiDiseaseRepository.getDrugKinkiDiseaseInfo();
        List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
        for (DrugKinkiDiseaseInfo drugKinkiDiseaseInfo : drugKinkiDiseaseInfos) {
            drugKinkiInterfaces.add(drugKinkiDiseaseInfo);
        }
        response.setResult(Boolean.TRUE);
        response.setKinkiType(CommonModelProto.KinkiType.KINKI_DIEASE);
        response.setData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugKinkiInterfaces, false, "")));
    	return response;
    }
    
    private BassServiceProto.BAS2015U00MasterDataResponse.Builder exportDosageToByteStringData(String directory) throws IOException {
		BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
    	
    	String fileName = directory + KinkiExportCsvName.DRUG_DOSAGE.getValue()  + ".csv";
        String zipFile = directory + KinkiExportCsvName.DRUG_DOSAGE.getValue()  + ".zip";
        
        List<DrugDosageMasterInfo> drugDosageMasterInfos =  drugDosageRepository.getDrugDosageMasterInfo();
        List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
        for (DrugDosageMasterInfo item : drugDosageMasterInfos) {
            drugKinkiInterfaces.add(item);
        }
        response.setResult(Boolean.TRUE);
        response.setKinkiType(CommonModelProto.KinkiType.DOSAGE);
        response.setData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugKinkiInterfaces,  false, "")));
    	return response;
    }
    
    private BassServiceProto.BAS2015U00MasterDataResponse.Builder exportDrugCheckingToByteStringData(String directory, String language) throws IOException {
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
    	
    	String fileName = directory + KinkiExportCsvName.DRUG_CHECKING.getValue()  + ".csv";
        String zipFile = directory + KinkiExportCsvName.DRUG_CHECKING.getValue()  + ".zip";
        List<DrugChecking> drugCheckings =  drugCheckingRepository.findByActiveFlgOrderByCreatedAsc(BigDecimal.ONE);
        List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
        for (DrugChecking drugChecking : drugCheckings) {
            DrugCheckingInfo item = new DrugCheckingInfo();
            BeanUtils.copyProperties(drugChecking, item, language);
            drugKinkiInterfaces.add(item);
        }
        response.setResult(Boolean.TRUE);
		response.setKinkiType(CommonModelProto.KinkiType.DRUG_CHECKING);
		response.setData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugKinkiInterfaces, false, "")));
		return response;
    }
    
    private BassServiceProto.BAS2015U00MasterDataResponse.Builder exportInterationToByteStringData(String directory, String language) throws IOException {
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
    	String fileName = directory + KinkiExportCsvName.DRUG_INTERACTION.getValue()  + ".csv";
        String zipFile = directory + KinkiExportCsvName.DRUG_INTERACTION.getValue()  + ".zip";

        List<DrugInteraction> drugInteractions = drugInteractionRepository.findByActiveFlgOrderByCreatedAsc(BigDecimal.ONE);
        List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
        for (DrugInteraction drugInteraction : drugInteractions) {
            DrugInteractionInfo item = new DrugInteractionInfo();
            BeanUtils.copyProperties(drugInteraction, item, language);
            drugKinkiInterfaces.add(item);
        }
        response.setResult(Boolean.TRUE);
        response.setKinkiType(CommonModelProto.KinkiType.INTERATION);
    	response.setData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugKinkiInterfaces,  false, "")));
    	return response;
    }
    
    private BassServiceProto.BAS2015U00MasterDataResponse.Builder exportGenericToByteStringData(String directory, String language) throws IOException {
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();
    	 String fileName = directory + KinkiExportCsvName.DRUG_GENERIC_NAME.getValue()  + ".csv";
         String zipFile = directory + KinkiExportCsvName.DRUG_GENERIC_NAME.getValue()  + ".zip";

         List<DrugGenericName> drugGenerics = drugGenericNameRepository.findByActiveFlgOrderByCreatedAsc(BigDecimal.ONE);
		List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
         for (DrugGenericName drugGeneric : drugGenerics) {
             DrugGenericNameInfo info = new DrugGenericNameInfo();
             BeanUtils.copyProperties(drugGeneric, info, language);
             drugKinkiInterfaces.add(info);
         }
         response.setResult(Boolean.TRUE);
         response.setKinkiType(CommonModelProto.KinkiType.GENERIC_NAME);
    	response.setData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugKinkiInterfaces, false, "")));
    	return response;
    }
    
    //import 4 table
    public BassServiceProto.BAS2015U00MasterDataResponse.Builder insertKinkiDosage(String fileName, String sysId, String language) throws IOException{
    	BassServiceProto.BAS2015U00MasterDataResponse.Builder response = BassServiceProto.BAS2015U00MasterDataResponse.newBuilder();

		String msg = null;
		try (CSVReader csvReader = new CSVReader(new InputStreamReader(new FileInputStream(fileName), FileUtils.encodingDetection(fileName)))) {
			List<DrugDosageMasterInfo> drugDosageMasterInfos = new ArrayList<>();
			String[] nextline;
			Integer lineNumber = 0;
			while ((nextline = csvReader.readNext()) != null) {
				++lineNumber;
				if (nextline.length > KinkiCsvLength.DRUG_DOSAGE.getValue()) {
					DrugDosageMasterInfo drugDosageMasterInfo = new DrugDosageMasterInfo(
							nextline[0], nextline[1], nextline[2],
							CommonUtils.parseInteger(nextline[3]),
							CommonUtils.parseInteger(nextline[4]), nextline[5],
							nextline[6], nextline[7], nextline[8], nextline[9],
							nextline[10], nextline[11], nextline[12],
							nextline[13], nextline[14], nextline[15],
							nextline[16], nextline[17], nextline[18],
							nextline[19], nextline[20], nextline[21],
							nextline[22], nextline[23], nextline[24],
							nextline[25], nextline[26], nextline[27],
							nextline[28], nextline[29], nextline[30],
							nextline[31], nextline[32], nextline[33],
							nextline[34], nextline[35], nextline[36],
							nextline[37], nextline[38], nextline[39],
							nextline[40], nextline[41], nextline[42],
							nextline[43], nextline[44], nextline[45],
							nextline[46], nextline[47], nextline[48],
							nextline[49], nextline[50], nextline[51],
							nextline[52], nextline[53], nextline[54],
							nextline[55], nextline[56], nextline[57],
							nextline[58], nextline[59], nextline[60],
							nextline[61], nextline[62], nextline[63],
							nextline[64], nextline[65], nextline[66],
							nextline[67], nextline[68], nextline[69],
							nextline[70], nextline[71], nextline[72],
							nextline[73], nextline[74], nextline[75],
							nextline[76], nextline[77], nextline[78],
							nextline[79], nextline[80], nextline[81],
							nextline[82], nextline[83], nextline[84],
							nextline[85], nextline[86], nextline[87],
							nextline[88], nextline[89], nextline[90],
							nextline[91], nextline[92], nextline[93],
							nextline[94], nextline[95], nextline[96],
							nextline[97], nextline[98], nextline[99],
							nextline[100]);
					drugDosageMasterInfos.add(drugDosageMasterInfo);
				} else {
					msg = String.valueOf(lineNumber);
				}
			}
			boolean result = insertDosage(drugDosageMasterInfos, sysId, language);
			result &= insertDosageNormal(drugDosageMasterInfos, sysId, language);
			result &= insertDosageStandard(drugDosageMasterInfos, sysId, language);
			result &= insertDosageAddition(drugDosageMasterInfos, sysId, language);

			response.setKinkiType(CommonModelProto.KinkiType.DOSAGE);
			response.setResult(result);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			return response;
		} catch (Exception e) {
			LOGGER.error("BAS2015U00MasterDataHandler error CsvFileReader in insertKinkiDosage" + e.getMessage());
			response.setKinkiType(CommonModelProto.KinkiType.KINKI_DIEASE);
			response.setResult(false);
			if (!StringUtils.isEmpty(msg)) {
				response.setMsg(msg);
			}
			throw new ExecutionException(response.build());
		} finally {
			FileUtils.deleteFile(fileName);

		}
    }
    
    private boolean insertDosage(List<DrugDosageMasterInfo> listDrugDosageMasterInfo, String sysId, String language){
    	List<DrugDosage> listInfo = new ArrayList<>();
    	if(!CollectionUtils.isEmpty(listDrugDosageMasterInfo)){
    		for(DrugDosageMasterInfo item : listDrugDosageMasterInfo){
    			DrugDosage info = new DrugDosage();
    	    	BeanUtils.copyProperties(item, info, language);
    	    	Date date = new Date();
    	    	info.setSysId(sysId);
    	    	info.setCreated(new Timestamp(date.getTime()));
    	    	info.setUpdated(new Timestamp(date.getTime()));
    	    	info.setActiveFlg(new BigDecimal(1));
    	    	listInfo.add(info);
    		}
    	}
    	drugDosageRepository.save(listInfo);
		return true;
    }
    
    private boolean insertDosageNormal(List<DrugDosageMasterInfo> listDrugDosageMasterInfo, String sysId, String language){
    	List<DrugDosageNormal> listInfo = new ArrayList<>();
    	if(!CollectionUtils.isEmpty(listDrugDosageMasterInfo)){
    		for(DrugDosageMasterInfo item : listDrugDosageMasterInfo){
    			DrugDosageNormal info = new DrugDosageNormal();
    	    	BeanUtils.copyProperties(item, info, language);
    	    	Date date = new Date();
    	    	info.setSysId(sysId);
    	    	info.setCreated(new Timestamp(date.getTime()));
    	    	info.setUpdated(new Timestamp(date.getTime()));
    	    	info.setActiveFlg(new BigDecimal(1));
    	    	listInfo.add(info);
    		}
    	}
    	drugDosageNormalRepository.save(listInfo);
		return true;
    }
    
    private boolean insertDosageStandard(List<DrugDosageMasterInfo> listDrugDosageMasterInfo, String sysId, String language){
    	List<DrugDosageStandard> listInfo = new ArrayList<>();
    	if(!CollectionUtils.isEmpty(listDrugDosageMasterInfo)){
    		for(DrugDosageMasterInfo item : listDrugDosageMasterInfo){
    			DrugDosageStandard info = new DrugDosageStandard();
    	    	BeanUtils.copyProperties(item, info, language);
    	    	Date date = new Date();
    	    	info.setSysId(sysId);
    	    	info.setCreated(new Timestamp(date.getTime()));
    	    	info.setUpdated(new Timestamp(date.getTime()));
    	    	info.setActiveFlg(new BigDecimal(1));
    	    	listInfo.add(info);
    		}
    	}
    	drugDosageStandardRepository.save(listInfo);
		return true;
    }
    
    private boolean insertDosageAddition(List<DrugDosageMasterInfo> listDrugDosageMasterInfo, String sysId, String language){
    	List<DrugDosageAddition> listInfo = new ArrayList<>();
    	if(!CollectionUtils.isEmpty(listDrugDosageMasterInfo)){
    		for(DrugDosageMasterInfo item : listDrugDosageMasterInfo){
    			DrugDosageAddition info = new DrugDosageAddition();
    	    	BeanUtils.copyProperties(item, info, language);
    	    	Date date = new Date();
    	    	info.setSysId(sysId);
    	    	info.setCreated(new Timestamp(date.getTime()));
    	    	info.setUpdated(new Timestamp(date.getTime()));
    	    	info.setActiveFlg(new BigDecimal(1));
    	    	listInfo.add(info);
    		}
    	}
    	drugDosageAddtionRepository.save(listInfo);
		return true;
    }

}
