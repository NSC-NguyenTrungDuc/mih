package nta.med.service.ihis.handler.kinki;

import au.com.bytecode.opencsv.CSVWriter;
import com.google.protobuf.ByteString;
import nta.med.common.util.type.Tuple;
import nta.med.core.domain.kinki.*;
import nta.med.core.glossary.KinkiTable;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.kinki.*;
import nta.med.data.model.ihis.system.*;
import nta.med.service.common.FileUtils;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.SyncKinkiCacheRequest;
import nta.med.service.ihis.proto.SystemServiceProto.SyncKinkiCacheResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.FileCopyUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.io.*;
import java.math.BigDecimal;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
import java.util.Properties;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class SyncKinkiCacheHandler extends ScreenHandler<SystemServiceProto.SyncKinkiCacheRequest, SystemServiceProto.SyncKinkiCacheResponse> {

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


    private static Properties properties = new Properties();
    private static final Log LOGGER = LogFactory.getLog(SyncKinkiCacheHandler.class);

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

    @Override
    public SyncKinkiCacheResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
    		SyncKinkiCacheRequest request) throws Exception {
    	
    	SystemServiceProto.SyncKinkiCacheResponse.Builder response = SystemServiceProto.SyncKinkiCacheResponse.newBuilder();
    	CommonModelProto.KinkiType kinkiType = request.getKinkiType();
    	String tableName = getTableName(kinkiType);
    	String url = getConfigProperty("kinki.download.path", "http://10.1.20.2/kinki/");
    	
    	Revision revision = revisionRepository.findByTableNameAndActiveFlg(tableName, BigDecimal.ONE);
    	if (revision != null && revision.getRevision() != null && revision.getFileName() != null) {
    		response.setPath(url + revision.getFileName());
    	}
    	
    	response.setKinkiType(kinkiType);
    	return response.build();
    }
    
    
    private String getTableName(CommonModelProto.KinkiType kinkiType){
    	
    	String tableName = "";
        if (kinkiType.equals(CommonModelProto.KinkiType.KINKI_MSG)) {
            tableName = KinkiTable.DRUG_KINKI_MESSAGE.getValue();
        } else if (kinkiType.equals(CommonModelProto.KinkiType.KINKI_DIEASE)) {
        	tableName = KinkiTable.DRUG_KINKI_DISEASE.getValue();
        } else if (kinkiType.equals(CommonModelProto.KinkiType.DOSAGE)) {
        	tableName = KinkiTable.DRUG_DOSAGE.getValue();
        } else if (kinkiType.equals(CommonModelProto.KinkiType.DRUG_CHECKING)) {
        	tableName = KinkiTable.DRUG_CHECKING.getValue();
        } else if (kinkiType.equals(CommonModelProto.KinkiType.INTERATION)) {
        	tableName = KinkiTable.DRUG_INTERACTION.getValue();
        } else if (kinkiType.equals(CommonModelProto.KinkiType.GENERIC_NAME)) {
        	tableName = KinkiTable.DRUG_GENERIC_NAME.getValue();
        }
        
        return tableName;
    }
    
//    private Tuple<Boolean, String> hasKinkiCacheFile(KinkiTable kinkiTable) {
//        Tuple<Boolean, String> map = new Tuple<>();
//        Revision revision = revisionRepository.findByTableNameAndActiveFlg(kinkiTable.getValue(), BigDecimal.ONE);
//        if (revision != null && revision.getRevision() != null && revision.getFileName() != null) {
//            //check exits in med app
//            File file = new File(revision.getFileName());
//            if (file.exists()) {
//                 map.set(true, revision.getFileName());
//            }
//            else
//            {
//                map.set(false, revision.getFileName());
//            }
//            return map;
//        }
//        map.set(false, "");
//        return map;
//    }
//    @Override
//    @Transactional
//    public SystemServiceProto.SyncKinkiCacheResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, SystemServiceProto.SyncKinkiCacheRequest request) throws Exception {
//
//        SystemServiceProto.SyncKinkiCacheResponse.Builder response = SystemServiceProto.SyncKinkiCacheResponse.newBuilder();
//        CommonModelProto.KinkiType kinkiType = request.getKinkiType();
//        Long timeStamp = Calendar.getInstance().getTime().getTime();
//        String directory = getConfigProperty("cache.path", "D:\\") + timeStamp + File.separator;
//
//        if (kinkiType.equals(CommonModelProto.KinkiType.KINKI_MSG)) {
//            Tuple<Boolean, String> map = hasKinkiCacheFile(KinkiTable.DRUG_KINKI_MESSAGE);
//            if(map.getV1())
//            {
//                Path path = Paths.get(map.getV2());
//                byte[] datas = Files.readAllBytes(path);
//                response.addData(ByteString.copyFrom(datas));
//            }
//            else
//            {
//                String fileName = directory + KinkiTable.DRUG_KINKI_MESSAGE.toString() + ".csv";
//                String zipFile = directory + KinkiTable.DRUG_KINKI_MESSAGE.getValue()  + ".zip";
//
//                List<DrugKinkiMessageInfo> drugKinkiDiseaseInfos =  drugKinkiMessageRepository.getDrugKinkiMessageInfo();
//                List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
//                for (DrugKinkiMessageInfo drugKinkiDiseaseInfo : drugKinkiDiseaseInfos) {
//                    drugKinkiInterfaces.add(drugKinkiDiseaseInfo);
//                }
//                response.addData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile,
//                        drugKinkiInterfaces, true, map.getV2())));
//
//            }
//
//        } else if (kinkiType.equals(CommonModelProto.KinkiType.KINKI_DIEASE)) {
//
//            Tuple<Boolean, String> map = hasKinkiCacheFile(KinkiTable.DRUG_KINKI_DISEASE);
//            if(map.getV1())
//            {
//                Path path = Paths.get(map.getV2());
//                byte[] datas = Files.readAllBytes(path);
//                response.addData(ByteString.copyFrom(datas));
//            }
//            else
//            {
//                String fileName = directory + KinkiTable.DRUG_KINKI_DISEASE.getValue()  + ".csv";
//                String zipFile = directory + KinkiTable.DRUG_KINKI_DISEASE.getValue()  + ".zip";
//
//                List<DrugKinkiDiseaseInfo> drugKinkiDiseaseInfos =  drugKinkiDiseaseRepository.getDrugKinkiDiseaseInfo();
//                List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
//                for (DrugKinkiDiseaseInfo drugKinkiDiseaseInfo : drugKinkiDiseaseInfos) {
//                    drugKinkiInterfaces.add(drugKinkiDiseaseInfo);
//                }
//
//                response.addData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugKinkiInterfaces, true, map.getV2())));
//            }
//
//
//        } else if (kinkiType.equals(CommonModelProto.KinkiType.DOSAGE)) {
//            Tuple<Boolean, String> map = hasKinkiCacheFile(KinkiTable.DRUG_DOSAGE);
//
//            List<String> scrFiles = new ArrayList<>();
//            String zipFile;
//            if(map.getV1())
//            {
//                File file = new File(map.getV2());
//                response.addData(ByteString.copyFrom(Files.readAllBytes(Paths.get(file.getPath()))));
//            }
//            else
//            {
//                directory = getConfigProperty("cache.path", "D:\\") + timeStamp + File.separator + KinkiTable.DRUG_DOSAGE + File.separator;;
//
//                File file = new File(directory);
//                if(!file.exists()) file.mkdirs();
//
//                scrFiles.add(createDrugDosageFile(directory, getLanguage(vertx, sessionId)));
//
//                scrFiles.add(createDrugDosageAdditionFile(directory,  getLanguage(vertx, sessionId)));
//                scrFiles.add(createDrugDosageNormalFile(directory, getLanguage(vertx, sessionId)));
//                scrFiles.add(createDrugDosageStandardFile(directory));
//                zipFile = directory + CommonModelProto.KinkiType.DOSAGE + ".zip";
//                FileUtils.zipFile(scrFiles, zipFile);
//                if(!StringUtils.isEmpty(map.getV2()))
//                {
//                    File parent  =  new File(map.getV2()).getParentFile();
//                    if(!parent.exists()) parent.mkdirs();
//                    FileCopyUtils.copy(new File(zipFile), new File(map.getV2()));
//                }
//
//                Path path = Paths.get(zipFile);
//                byte[] datas = Files.readAllBytes(path);
//                FileUtils.deleteDirectory(new File(getConfigProperty("cache.path", "D:\\") + timeStamp));
//                response.addData(ByteString.copyFrom(datas));
//            }
//
//
//        } else if (kinkiType.equals(CommonModelProto.KinkiType.DRUG_CHECKING)) {
//            Tuple<Boolean, String> map = hasKinkiCacheFile(KinkiTable.DRUG_CHECKING);
//            if(map.getV1())
//            {
//                Path path = Paths.get(map.getV2());
//                byte[] datas = Files.readAllBytes(path);
//                response.addData(ByteString.copyFrom(datas));
//            }
//            else
//            {
//                String fileName = directory + KinkiTable.DRUG_CHECKING.getValue()  + ".csv";
//                String zipFile = directory + KinkiTable.DRUG_CHECKING.getValue()  + ".zip";
//
//                List<DrugChecking> drugCheckings =  drugCheckingRepository.findByActiveFlgOrderByCreatedAsc(BigDecimal.ONE);
//                List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
//                for (DrugChecking drugChecking : drugCheckings) {
//                    DrugCheckingInfo item = new DrugCheckingInfo();
//                    BeanUtils.copyProperties(drugChecking, item, getLanguage(vertx, sessionId));
//                    drugKinkiInterfaces.add(item);
//                }
//
//                response.addData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugKinkiInterfaces, true, map.getV2())));
//            }
//
//
//
//        } else if (kinkiType.equals(CommonModelProto.KinkiType.INTERATION)) {
//            Tuple<Boolean, String> map = hasKinkiCacheFile(KinkiTable.DRUG_INTERACTION);
//            if(map.getV1())
//            {
//                Path path = Paths.get(map.getV2());
//                byte[] datas = Files.readAllBytes(path);
//                response.addData(ByteString.copyFrom(datas));
//            }
//            else
//            {
//                String fileName = directory + KinkiTable.DRUG_INTERACTION.getValue()  + ".csv";
//                String zipFile = directory + KinkiTable.DRUG_INTERACTION.getValue()  + ".zip";
//
//                List<DrugInteraction> drugInteractions = drugInteractionRepository.findByActiveFlgOrderByCreatedAsc(BigDecimal.ONE);
//                List<DrugKinkiInterface> drugKinkiInterfaces = new ArrayList<>();
//                for (DrugInteraction drugInteraction : drugInteractions) {
//                    DrugInteractionInfo item = new DrugInteractionInfo();
//                    BeanUtils.copyProperties(drugInteraction, item, getLanguage(vertx, sessionId));
//                    drugKinkiInterfaces.add(item);
//                }
//
//                response.addData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugKinkiInterfaces, true, map.getV2())));
//            }
//
//
//
//        } else if (kinkiType.equals(CommonModelProto.KinkiType.GENERIC_NAME)) {
//            Tuple<Boolean, String> map = hasKinkiCacheFile(KinkiTable.DRUG_GENERIC_NAME);
//            if(map.getV1())
//            {
//                Path path = Paths.get(map.getV2());
//                byte[] datas = Files.readAllBytes(path);
//                response.addData(ByteString.copyFrom(datas));
//            }
//            else
//            {
//                String fileName = directory + KinkiTable.DRUG_GENERIC_NAME.getValue()  + ".csv";
//                String zipFile = directory + KinkiTable.DRUG_GENERIC_NAME.getValue()  + ".zip";
//
//                List<DrugGenericName> drugGenerics = drugGenericNameRepository.findByActiveFlgOrderByCreatedAsc(BigDecimal.ONE);
//                List<DrugKinkiInterface> drugGenericNameInfos = new ArrayList<>();
//                for (DrugGenericName drugGeneric : drugGenerics) {
//                    DrugGenericNameInfo info = new DrugGenericNameInfo();
//                    BeanUtils.copyProperties(drugGeneric, info, getLanguage(vertx, sessionId));
//                    drugGenericNameInfos.add(info);
//                }
//                response.addData(ByteString.copyFrom(FileUtils.getKinkiMasterData(directory, fileName, zipFile, drugGenericNameInfos, true, map.getV2())));
//            }
//
//
//        }
//        return response.build();
//
//    }
//
//
//    private String createDrugDosageFile(String directory, String language) throws IOException {
//
//
//        File file = new File(directory);
//        if(!file.exists()) file.mkdirs();
//        List<DrugDosage> drugDosages = drugDosageRepository.findByActiveFlgOrderByCreatedAsc(BigDecimal.ONE);
//        List<String[]> strings = new ArrayList<>();
//        String fileName = directory + KinkiTable.DRUG_DOSAGE  + ".csv";
//        CSVWriter out = new CSVWriter(new OutputStreamWriter(
//                new FileOutputStream(fileName), "UTF8"), ',');
//        for (DrugDosage drugDosage : drugDosages) {
//            DrugDosageInfo info = new DrugDosageInfo();
//            BeanUtils.copyProperties(drugDosage, info, language);
//            strings.add(info.convertItemToArray());
//        }
//        out.writeAll(strings);
//        out.flush();
//        out.close();
//
//        return fileName;
//    }
//
//    private String createDrugDosageStandardFile(String directory) throws IOException {
//
//        List<DrugDosageStandardInfo> listNormal = drugDosageStandardRepository.getDrugDosageStandardInfo();
//        String fileName = directory + KinkiTable.DRUG_DOSAGE_STANDARD  + ".csv";
//        CSVWriter out = new CSVWriter(new OutputStreamWriter(
//                new FileOutputStream(fileName), "UTF8"), ',');
//
//        List<String[]> strings = new ArrayList<>();
//        if (!CollectionUtils.isEmpty(listNormal)) {
//            for (DrugDosageStandardInfo item : listNormal) {
//                strings.add(item.convertItemToArray());
//            }
//        }
//        out.writeAll(strings);
//        out.flush();
//        out.close();
//
//        return fileName;
//
//    }
//    private String createDrugDosageAdditionFile(String directory, String language) throws IOException {
//
//        String fileName = directory + KinkiTable.DRUG_DOSAGE_ADDITION  + ".csv";
//        List<DrugDosageAddition> listDosageAddition = drugDosageAddtionRepository.findByActiveFlgOrderByCreatedAsc(BigDecimal.ONE);
//        CSVWriter out = new CSVWriter(new OutputStreamWriter(
//                new FileOutputStream(fileName), "UTF8"), ',');
//        List<String[]> strings = new ArrayList<>();
//        for (DrugDosageAddition item : listDosageAddition) {
//            DrugDosageAddtionInfo info = new DrugDosageAddtionInfo();
//            BeanUtils.copyProperties(item, info, language);
//            strings.add(info.convertItemToArray());
//        }
//        out.writeAll(strings);
//        out.flush();
//        out.close();
//
//
//        return fileName;
//    }
//
//    private String createDrugDosageNormalFile(String directory, String language) throws IOException {
//
//        String fileName = directory + KinkiTable.DRUG_DOSAGE_NORMAL  + ".csv";
//        List<DrugDosageNormal> listDrugDosageNormal = drugDosageNormalRepository.findByActiveFlgOrderByCreatedAsc(BigDecimal.ONE);
//        CSVWriter out = new CSVWriter(new OutputStreamWriter(
//                new FileOutputStream(fileName), "UTF8"), ',');
//
//        List<String[]> strings = new ArrayList<>();
//        for (DrugDosageNormal item : listDrugDosageNormal) {
//            DrugDosageNormalInfo info = new DrugDosageNormalInfo();
//            BeanUtils.copyProperties(item, info, language);
//            strings.add(info.convertItemToArray());
//        }
//        out.writeAll(strings);
//        out.flush();
//        out.close();
//
//        return fileName;
//    }

}
