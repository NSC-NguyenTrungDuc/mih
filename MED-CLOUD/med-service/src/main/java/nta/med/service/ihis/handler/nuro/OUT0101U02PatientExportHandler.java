package nta.med.service.ihis.handler.nuro;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Properties;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import com.google.protobuf.ByteString;

import nta.med.common.util.DateTimes;
import nta.med.core.glossary.ExportPatientHeader;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.OUT0101U02PatientExportInfo;
import nta.med.data.model.ihis.nuro.OUT0101U02SelectedFieldPatientExportInfo;
import nta.med.data.model.ihis.system.ExportCsvInterface;
import nta.med.service.common.FileUtils;
import nta.med.service.ihis.handler.bass.BAS2015U00MasterDataHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.OUT0101U02PatientExportRequest;
import nta.med.service.ihis.proto.NuroServiceProto.OUT0101U02PatientExportResponse;

@Service
@Scope("prototype")
public class OUT0101U02PatientExportHandler extends ScreenHandler<NuroServiceProto.OUT0101U02PatientExportRequest, NuroServiceProto.OUT0101U02PatientExportResponse> {
	private static final Log LOG = LogFactory.getLog(OUT0101U02PatientExportHandler.class);
	@Resource
	private Out0101Repository out0101Repository;
	
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
	
	
	@Override
	@Transactional(readOnly = true)
	public OUT0101U02PatientExportResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OUT0101U02PatientExportRequest request) throws Exception {
		NuroServiceProto.OUT0101U02PatientExportResponse.Builder response = NuroServiceProto.OUT0101U02PatientExportResponse.newBuilder();
		Long timeStamp = Calendar.getInstance().getTime().getTime();
		String directory = getConfigProperty("cache.path", "D:\\") + timeStamp + File.separator;
		Date fromDate = DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD);
		Date toDate = new Date(DateTimes.addSeconds(DateTimes.addDays(DateTimes.parse(DateUtil.PATTERN_YYMMDD, request.getEndDate()), 1), -1));
		String language = getLanguage(vertx, sessionId); 
		String hospCode = getHospitalCode(vertx, sessionId); 
		List<OUT0101U02SelectedFieldPatientExportInfo> exportInfos = new ArrayList<OUT0101U02SelectedFieldPatientExportInfo>();
		NuroModelProto.OUT0101U02PatientExportInfo selectedHeader = request.getHeaderItem();
		exportInfos.add(parseSelectedHeader(selectedHeader, language));
		List<OUT0101U02PatientExportInfo> patients =  out0101Repository.getOUT0101U02PatientExportInfo(hospCode, fromDate, toDate);
		exportInfos.addAll(parseSelectedPatientInfos(patients, selectedHeader));
		response = exportMsgToByteStringData(exportInfos, directory);
		return response.build();
	}
	
	private OUT0101U02PatientExportResponse.Builder exportMsgToByteStringData(List<OUT0101U02SelectedFieldPatientExportInfo> exportInfos, String directory) throws IOException {
		NuroServiceProto.OUT0101U02PatientExportResponse.Builder response = NuroServiceProto.OUT0101U02PatientExportResponse.newBuilder();
		String filePath = String.format("%s%s", directory, "PatientList.csv");
		String fileZipPath = String.format("%s%s", directory, "PatientList.zip"); 
        List<ExportCsvInterface> exportData = new ArrayList<>();
        for (OUT0101U02SelectedFieldPatientExportInfo exportInfo : exportInfos) {
        	exportData.add(exportInfo);
        }
        response.setData(ByteString.copyFrom(FileUtils.getExportCsvData(directory, filePath, fileZipPath, exportData)));
        return response;
    }
	
	private List<OUT0101U02SelectedFieldPatientExportInfo> parseSelectedPatientInfos(List<OUT0101U02PatientExportInfo> patients, NuroModelProto.OUT0101U02PatientExportInfo selectedHeader){
		List<OUT0101U02SelectedFieldPatientExportInfo> exportInfos = new ArrayList<OUT0101U02SelectedFieldPatientExportInfo>();
		if(!CollectionUtils.isEmpty(patients)){
			for(OUT0101U02PatientExportInfo item : patients){
				OUT0101U02SelectedFieldPatientExportInfo info = new OUT0101U02SelectedFieldPatientExportInfo();
				if(!StringUtils.isEmpty(selectedHeader.getCreatedDate())){
					info.setCreatedDate(item.getCreatedDate() == null ? "" : item.getCreatedDate());
				}
				if(!StringUtils.isEmpty(selectedHeader.getCreatedAdmin())){
					info.setCreatedAdmin(item.getCreatedAdmin() == null ? "" : item.getCreatedAdmin());
				}
				if(!StringUtils.isEmpty(selectedHeader.getUpdateDate())){
					info.setUpdateDate(item.getUpdateDate() == null ? "" : item.getUpdateDate());
				}
				if(!StringUtils.isEmpty(selectedHeader.getUpdateAdmin())){
					info.setUpdateAdmin(item.getUpdateAdmin() == null ? "" : item.getUpdateAdmin());
				}
				if(!StringUtils.isEmpty(selectedHeader.getHospitalCode())){
					info.setHospitalCode(item.getHospitalCode());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPatientCode())){
					info.setPatientCode(item.getPatientCode() == null ? "" : item.getPatientCode());
				}
				if(!StringUtils.isEmpty(selectedHeader.getSuname())){
					info.setSuname(item.getSuname() == null ? "" : item.getSuname());
				}
				if(!StringUtils.isEmpty(selectedHeader.getSuname2())){
					info.setSuname2(item.getSuname2() == null ? "" : item.getSuname2());
				}
				if(!StringUtils.isEmpty(selectedHeader.getSex())){
					info.setSex(item.getSex() == null ? "" : item.getSex());
				}
				if(!StringUtils.isEmpty(selectedHeader.getBirthday())){
					info.setBirthday(item.getBirthday() == null ? "" : item.getBirthday());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPostalCode())){
					info.setPostalCode(item.getPostalCode() == null ? "" : item.getPostalCode());
				}
				if(!StringUtils.isEmpty(selectedHeader.getAddress1())){
					info.setAddress1(item.getAddress1() == null ? "" : item.getAddress1());
				}
				if(!StringUtils.isEmpty(selectedHeader.getAddress2())){
					info.setAddress2(item.getAddress2() == null ? "" : item.getAddress2());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneNumber())){
					info.setPhoneNumber(item.getPhoneNumber() == null ? "" : item.getPhoneNumber());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneNumber2())){
					info.setPhoneNumber2(item.getPhoneNumber2() == null ? "" : item.getPhoneNumber2());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneNumber3())){
					info.setPhoneNumber3(item.getPhoneNumber3() == null ? "" : item.getPhoneNumber3());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneType1())){
					info.setPhoneType1(item.getPhoneType1() == null ? "" : item.getPhoneType1());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneType2())){
					info.setPhoneType2(item.getPhoneType2() == null ? "" : item.getPhoneType2());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneType3())){
					info.setPhoneType3(item.getPhoneType3() == null ? "" : item.getPhoneType3());
				}
				if(!StringUtils.isEmpty(selectedHeader.getInsuranceType())){
					info.setInsuranceType(item.getInsuranceType() == null ? "" : item.getInsuranceType());
				}
				if(!StringUtils.isEmpty(selectedHeader.getInteruptedReception())){
					info.setInteruptedReception(item.getInteruptedReception() == null ? "" : item.getInteruptedReception());
				}
				if(!StringUtils.isEmpty(selectedHeader.getInteruptedReceptionReason())){
					info.setInteruptedReceptionReason(item.getInteruptedReceptionReason() == null ? "" : item.getInteruptedReceptionReason());
				}
				if(!StringUtils.isEmpty(selectedHeader.getDetete())){
					info.setDetete(item.getDetete() == null ? "" : item.getDetete());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPatientNote())){
					info.setPatientNote(item.getPatientNote() == null ? "" : item.getPatientNote());
				}
				if(!StringUtils.isEmpty(selectedHeader.getEmailAddress())){
					info.setEmailAddress(item.getEmailAddress() == null ? "" : item.getEmailAddress());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPaceMakerYn())){
					info.setPaceMakerYn(item.getPaceMakerYn() == null ? "" : item.getPaceMakerYn());
				}
				if(!StringUtils.isEmpty(selectedHeader.getSelfPaceMaker())){
					info.setSelfPaceMaker(item.getSelfPaceMaker() == null ? "" : item.getSelfPaceMaker());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPassword())){
					info.setPassword(item.getPassword() == null ? "" : item.getPassword());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPatientType())){
					info.setPatientType(item.getPatientType() == null ? "" : item.getPatientType());
				}
				exportInfos.add(info);
			}
		}
		return exportInfos;
	}
	
	private OUT0101U02SelectedFieldPatientExportInfo parseSelectedHeader(NuroModelProto.OUT0101U02PatientExportInfo selectedHeader, String language){
		OUT0101U02SelectedFieldPatientExportInfo info = new OUT0101U02SelectedFieldPatientExportInfo();
		if(selectedHeader != null){
				if(!StringUtils.isEmpty(selectedHeader.getCreatedDate())){
					info.setCreatedDate(ExportPatientHeader.newInstance(language).createdDate());
				}
				if(!StringUtils.isEmpty(selectedHeader.getCreatedAdmin())){
					info.setCreatedAdmin(ExportPatientHeader.newInstance(language).createdAdmin());
				}
				if(!StringUtils.isEmpty(selectedHeader.getUpdateDate())){
					info.setUpdateDate(ExportPatientHeader.newInstance(language).updatedDate());
				}
				if(!StringUtils.isEmpty(selectedHeader.getUpdateAdmin())){
					info.setUpdateAdmin(ExportPatientHeader.newInstance(language).updatedAdmin());
				}
				if(!StringUtils.isEmpty(selectedHeader.getHospitalCode())){
					info.setHospitalCode(ExportPatientHeader.newInstance(language).hospitalCode());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPatientCode())){
					info.setPatientCode(ExportPatientHeader.newInstance(language).patientCode());
				}
				if(!StringUtils.isEmpty(selectedHeader.getSuname())){
					info.setSuname(ExportPatientHeader.newInstance(language).suname());
				}
				if(!StringUtils.isEmpty(selectedHeader.getSuname2())){
					info.setSuname2(ExportPatientHeader.newInstance(language).suname2());
				}
				if(!StringUtils.isEmpty(selectedHeader.getSex())){
					info.setSex(ExportPatientHeader.newInstance(language).sex());
				}
				if(!StringUtils.isEmpty(selectedHeader.getBirthday())){
					info.setBirthday(ExportPatientHeader.newInstance(language).birthday());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPostalCode())){
					info.setPostalCode(ExportPatientHeader.newInstance(language).postalCode());
				}
				if(!StringUtils.isEmpty(selectedHeader.getAddress1())){
					info.setAddress1(ExportPatientHeader.newInstance(language).address1());
				}
				if(!StringUtils.isEmpty(selectedHeader.getAddress2())){
					info.setAddress2(ExportPatientHeader.newInstance(language).address2());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneNumber())){
					info.setPhoneNumber(ExportPatientHeader.newInstance(language).phoneNumber());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneNumber2())){
					info.setPhoneNumber2(ExportPatientHeader.newInstance(language).phoneNumber2());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneNumber3())){
					info.setPhoneNumber3(ExportPatientHeader.newInstance(language).phoneNumber3());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneType1())){
					info.setPhoneType1(ExportPatientHeader.newInstance(language).phoneType1());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneType2())){
					info.setPhoneType2(ExportPatientHeader.newInstance(language).phoneType2());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPhoneType3())){
					info.setPhoneType3(ExportPatientHeader.newInstance(language).phoneType3());
				}
				if(!StringUtils.isEmpty(selectedHeader.getInsuranceType())){
					info.setInsuranceType(ExportPatientHeader.newInstance(language).insuranceType());
				}
				if(!StringUtils.isEmpty(selectedHeader.getInteruptedReception())){
					info.setInteruptedReception(ExportPatientHeader.newInstance(language).interuptedReception());
				}
				if(!StringUtils.isEmpty(selectedHeader.getInteruptedReceptionReason())){
					info.setInteruptedReceptionReason(ExportPatientHeader.newInstance(language).interuptedReceptionReason());
				}
				if(!StringUtils.isEmpty(selectedHeader.getDetete())){
					info.setDetete(ExportPatientHeader.newInstance(language).delete());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPatientNote())){
					info.setPatientNote(ExportPatientHeader.newInstance(language).patientNode());
				}
				if(!StringUtils.isEmpty(selectedHeader.getEmailAddress())){
					info.setEmailAddress(ExportPatientHeader.newInstance(language).emailAddress());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPaceMakerYn())){
					info.setPaceMakerYn(ExportPatientHeader.newInstance(language).paceMakerYn());
				}
				if(!StringUtils.isEmpty(selectedHeader.getSelfPaceMaker())){
					info.setSelfPaceMaker(ExportPatientHeader.newInstance(language).selfPaceMaker());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPassword())){
					info.setPassword(ExportPatientHeader.newInstance(language).password());
				}
				if(!StringUtils.isEmpty(selectedHeader.getPatientType())){
					info.setPatientType(ExportPatientHeader.newInstance(language).patientType());
				}
		}
		return info;
	}

}
