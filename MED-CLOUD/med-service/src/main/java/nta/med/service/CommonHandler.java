package nta.med.service;

import com.google.protobuf.Message;

import nta.med.core.caching.model.medi.drgs.InformationSchemaColumn;
import nta.med.core.config.Configuration;
import nta.med.core.domain.ifs.Ifs7301;
import nta.med.core.domain.ifs.Ifs7302;
import nta.med.core.glossary.InOutType;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.dao.medi.ifs.Ifs7301Repository;
import nta.med.data.dao.medi.ifs.Ifs7302Repository;
import nta.med.data.model.ihis.drgs.PrJihDrgIfsProcInfo;
import nta.med.data.model.ihis.drgs.PrJihDrgIfsProcPatientInfo;
import nta.med.service.caching.CacheService;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;

import javax.annotation.Resource;

import java.util.Date;
import java.util.List;
import java.util.Map;

@Service
@Transactional
public abstract class CommonHandler<REQ extends Message, RES extends Message> extends ScreenHandler<REQ, RES> {
	private static final Log LOG = LogFactory.getLog(CommonHandler.class);
	@Autowired
	private Configuration configuration;
	
	@Resource
	public CacheService cacheService;
	@Resource
	private Drg2010Repository drg2010Repository;
	@Resource
	private Drg3010Repository drg3010Repository;
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Ifs7301Repository ifs7301Repository;
	@Resource
	private Ifs7302Repository ifs7302Repository;
	
	private Map<String, InformationSchemaColumn> mapIfs7301 = null;
	private Map<String, InformationSchemaColumn> mapIfs7302 = null;

	public String prJihDrgIfsProc(String hospitalCode, String ioGubun,
								  Double fkdrg, String userId) {
		String oErr = "1";
		Ifs7301 r1 = new Ifs7301();
		if (InOutType.OUT.getValue().equals(ioGubun)) {
			List<PrJihDrgIfsProcInfo> listInfo = drg2010Repository.getPrJihDrgIfsProcOutInfo(hospitalCode, fkdrg);
			if(!CollectionUtils.isEmpty(listInfo)) {
				PrJihDrgIfsProcInfo info = listInfo.get(listInfo.size() - 1);
				r1.setRecGubunPat(ifsPad7301("REC_GUBUN_PAT", "VARCHAR", info.getRecGubunPat()));
				r1.setJojeDate(ifsPad7301("JOJE_DATE", "VARCHAR", info.getJojeDate()));
				r1.setDrgBunho(CommonUtils.parseDouble(ifsPad7301("DRG_BUNHO", "NUMBER", info.getDrgBunho().toString())));
				r1.setGwa(ifsPad7301("GWA", "VARCHAR", info.getGwa()));
				r1.setBunho(ifsPad7301("BUNHO", "VARCHAR", info.getBunho()));
				r1.setPatName(ifsPad7301("PAT_NAME", "VARCHAR", info.getPatName()));
				r1.setBirthday(ifsPad7301("BIRTHDAY", "VARCHAR", info.getBirthday()));
				r1.setSex(ifsPad7301("SEX", "VARCHAR", info.getSex()));
				r1.setCancerFlag(ifsPad7301("CANCER_FLAG", "VARCHAR", info.getCancerFlag()));
				r1.setRecGubunMemo(ifsPad7301("REC_GUBUN_MEMO", "VARCHAR", info.getRecGubunMemo()));
				r1.setPatMemo(ifsPad7301("PAT_MEMO", "VARCHAR", info.getPatMemo()));
				r1.setRecGubunDrguser(ifsPad7301("REC_GUBUN_DRGUSER", "VARCHAR", info.getRecGubunDrguser()));
				r1.setDrguserName(ifsPad7301("DRGUSER_NAME", "VARCHAR", info.getDrguserName()));
				r1.setRecGubunDoctor(ifsPad7301("REC_GUBUN_DOCTOR", "VARCHAR", info.getRecGubunDoctor()));
				r1.setDoctorName(ifsPad7301("DOCTOR_NAME", "VARCHAR", info.getDoctorName()));
			}
		} else if (InOutType.IN.getValue().equals(ioGubun)) {
			List<PrJihDrgIfsProcInfo> listInfo = drg3010Repository.getPrJihDrgIfsProcInInfo(hospitalCode, fkdrg);
			if(!CollectionUtils.isEmpty(listInfo)) {
				PrJihDrgIfsProcInfo info = listInfo.get(listInfo.size() - 1);
				r1.setRecGubunPat(ifsPad7301("REC_GUBUN_PAT", "VARCHAR", info.getRecGubunPat()));
				r1.setJojeDate(ifsPad7301("JOJE_DATE", "VARCHAR", info.getJojeDate()));
				r1.setDrgBunho(CommonUtils.parseDouble(ifsPad7301("DRG_BUNHO", "NUMBER", info.getDrgBunho().toString())));
				r1.setGwa(ifsPad7301("GWA", "VARCHAR", info.getGwa()));
				r1.setBunho(ifsPad7301("BUNHO", "VARCHAR", info.getBunho()));
				r1.setPatName(ifsPad7301("PAT_NAME", "VARCHAR", info.getPatName()));
				r1.setBirthday(ifsPad7301("BIRTHDAY", "VARCHAR", info.getBirthday()));
				r1.setSex(ifsPad7301("SEX", "VARCHAR", info.getSex()));
				r1.setCancerFlag(ifsPad7301("CANCER_FLAG", "VARCHAR", info.getCancerFlag()));
				r1.setRecGubunMemo(ifsPad7301("REC_GUBUN_MEMO", "VARCHAR", info.getRecGubunMemo()));
				r1.setPatMemo(ifsPad7301("PAT_MEMO", "VARCHAR", info.getPatMemo()));
				r1.setRecGubunDrguser(ifsPad7301("REC_GUBUN_DRGUSER", "VARCHAR", info.getRecGubunDrguser()));
				r1.setDrguserName(ifsPad7301("DRGUSER_NAME", "VARCHAR", info.getDrguserName()));
				r1.setRecGubunDoctor(ifsPad7301("REC_GUBUN_DOCTOR", "VARCHAR", info.getRecGubunDoctor()));
				r1.setDoctorName(ifsPad7301("DOCTOR_NAME", "VARCHAR", info.getDoctorName()));
			}
		}
		Double pkifs7301 = CommonUtils.parseDouble(commonRepository.getNextVal("IFS7301_SEQ"));
		r1.setPkifs7301(pkifs7301);
		r1.setSysId(userId);
		r1.setSysDate(new Date());
		r1.setUpdId(userId);
		r1.setUpdDate(new Date());
		r1.setHospCode(hospitalCode);
		r1.setFkdrg5010(fkdrg);
		LOG.info(r1.toString());
		ifs7301Repository.save(r1);
		
		if (InOutType.OUT.getValue().equals(ioGubun)) {
			List<PrJihDrgIfsProcPatientInfo> listInfo = drg2010Repository.getPrJihDrgIfsProcPatientOutInfo(hospitalCode, r1.getBunho(), fkdrg);
			if(!CollectionUtils.isEmpty(listInfo)) {
				for(int i = 0; i <listInfo.size(); i++) {
					insertIfs7302(listInfo.get(i), userId, pkifs7301,i, hospitalCode);
				}
			}
		} else if (InOutType.IN.getValue().equals(ioGubun)) {
			List<PrJihDrgIfsProcPatientInfo> listInfo = drg3010Repository.getPrJihDrgIfsProcPatientInInfo(hospitalCode, r1.getBunho(), fkdrg);
			if(!CollectionUtils.isEmpty(listInfo)) {
				for(int i = 0; i <listInfo.size(); i++) {
					insertIfs7302(listInfo.get(i), userId, pkifs7301,i, hospitalCode);
				}
			}
		}
		oErr = "0";
		return oErr;
	}
	
	public void insertIfs7302(PrJihDrgIfsProcPatientInfo info, String userId, Double pkifs7301, Integer drgSeq, String hospitalCode){
		Ifs7302 r2 = new Ifs7302();
		r2.setSysId(userId);
		r2.setSysDate(new Date());
		r2.setUpdId(userId);
		r2.setUpdDate(new Date());
		r2.setHospCode(hospitalCode);
		r2.setFkifs7301(pkifs7301);
		r2.setDrgSeq(CommonUtils.parseDouble(ifsPad7302("DRG_SEQ", "NUMBER", drgSeq.toString())));
		r2.setRecGubunDrg(ifsPad7302("REC_GUBUN_DRG", "VARCHAR", info.getRecGubunDrg()));
		r2.setDrgCode(ifsPad7302("DRG_CODE", "VARCHAR", info.getDrgCode()));
		r2.setSuryang(ifsPad7302("SURYANG", "VARCHAR", info.getSuryang()));
		r2.setDrgType(ifsPad7302("DRG_TYPE", "VARCHAR", info.getDrgType()));
		r2.setBogyongCode(ifsPad7302("BOGYONG_CODE", "VARCHAR", info.getBogyongCode()));
		r2.setNalsu(ifsPad7302("NALSU", "VARCHAR", info.getNalsu()));
		LOG.info(r2.toString());
		ifs7302Repository.save(r2);
	}
	
	public String ifsPad7301(String column, String dataType, String value){
		return fnIfsPad(column, dataType, value, mapIfs7301, configuration.getSchema()+":IFS7301");
	}
	public String ifsPad7302(String column, String dataType, String value){
		return fnIfsPad(column, dataType, value, mapIfs7302, configuration.getSchema()+":IFS7302");
	}
	
	public String fnIfsPad(String column, String dataType, String value, Map<String, InformationSchemaColumn> mapSchemaColumn, String tableName){
		LOG.info("fnIfsPad tableName=" + tableName + ", column="+ column + ", dataType="+ dataType + ", value=");
		if(mapSchemaColumn == null){
			mapSchemaColumn = cacheService.getSchemaCache().findAll(tableName);
		}
		int size = 0;
		if(mapSchemaColumn.get(column).getCharacterMaximunLength() != null){
			size =	mapSchemaColumn.get(column).getCharacterMaximunLength().intValue();
		}
		if(dataType.equals("NUMBER")){
			if(value == null){
				value = "0";
			}
			return StringUtils.leftPad(value, size, "0");
		}else if (dataType.equals("VARCHAR")){
			if(value == null){
				value = " ";
			}
			return StringUtils.rightPad(value, size, " ");
		}else{
			return value;
		}
	}
	
}
