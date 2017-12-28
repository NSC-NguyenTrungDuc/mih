package nta.med.service.ihis.handler.system;

import nta.med.core.caching.model.medi.drgs.InformationSchemaColumn;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.config.Configuration;
import nta.med.core.domain.ifs.Ifs7401;
import nta.med.core.domain.phy.Phy7401;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.com.ComSeqRepository;
import nta.med.data.dao.medi.ifs.Ifs7401Repository;
import nta.med.data.dao.medi.phy.Phy7401Repository;
import nta.med.service.CommonHandler;
import nta.med.service.caching.CacheService;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OcsoProcHQNInterfaceRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OcsoProcHQNInterfaceResponse;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Date;
import java.util.Map;

@Service
@Scope("prototype")
@Transactional
public class OcsoProcHQNInterfaceHandler extends CommonHandler <SystemServiceProto.OcsoProcHQNInterfaceRequest, SystemServiceProto.OcsoProcHQNInterfaceResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoProcHQNInterfaceHandler.class);

	@Autowired
    private Configuration configuration;
	
	@Resource
	private Phy7401Repository phy7401Repository;
	
	@Resource
	private Ifs7401Repository ifs7401Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private ComSeqRepository comSeqRepository;
	
	@Resource
	public CacheService cacheService;
	
	private Map<String, InformationSchemaColumn> mapIfs7401 = null;
	
	@Override
	public OcsoProcHQNInterfaceResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoProcHQNInterfaceRequest request) throws Exception {
			SystemServiceProto.OcsoProcHQNInterfaceResponse.Builder response = SystemServiceProto.OcsoProcHQNInterfaceResponse.newBuilder();
			String oErr = "1";
			SystemModelProto.OcsoSelectedPatientInfo info = request.getPatientInfo();
			String hospCode = getHospitalCode(vertx, sessionId);
			Phy7401 phy7401 = new Phy7401();
			phy7401.setSysId("IF");
			phy7401.setSysDate(new Date());
			phy7401.setHospCode(hospCode);
			Date jubsuDate = DateUtil.toDate(info.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
			phy7401.setJubsuDate(jubsuDate);
			phy7401.setDataDubun(request.getDataDubun());
			phy7401.setInOutGubun(request.getIoGubun());
			phy7401.setBunho(info.getBunho());
			Double fk = CommonUtils.parseDouble(info.getNaewonKey());
			if("O".equals(phy7401.getInOutGubun())){
				phy7401.setFkout1001(fk);
			}else{
				phy7401.setFkinp1001(fk);
			}
			phy7401.setIfSendFlag("N");
			
			String pkStr = commonRepository.getNextVal("PHY7401_SEQ");
			Double pk = CommonUtils.parseDouble(pkStr);
			phy7401.setPkphy7401(pk);
			
			String seqKey = hospCode+ DateUtil.toString(jubsuDate, DateUtil.PATTERN_YYMMDD_BLANK);
			Double seq = comSeqRepository.getMaxSeq(hospCode, "PHY7401", "BUNHO_SEQ", seqKey);
			phy7401.setSeq(seq);
			
			phy7401Repository.save(phy7401);
			
			response.setPkphy7401(pkStr);
			
			if(seq == null){
				throw new ExecutionException(response.build());
			}
			
			Ifs7401 ifs7401 = new Ifs7401();
			if(!StringUtils.isEmpty(pkStr)){
				ifs7401.setBunho(ifsPad7401("BUNHO", "VARCHAR", info.getBunho()));
				ifs7401.setNameKana(ifsPad7401("NAME_KANA", "VARCHAR", info.getSuname2()));
				ifs7401.setNameKanji(ifsPad7401("NAME_KANJI", "VARCHAR", info.getSuname()));
				ifs7401.setSex(ifsPad7401("SEX", "VARCHAR", info.getSex()));
				ifs7401.setBirth(ifsPad7401("BIRTH", "VARCHAR", info.getBirth().replace("/", "")));
				ifs7401.setZipCode(ifsPad7401("ZIP_CODE", "VARCHAR", info.getZipCode()));
				ifs7401.setAddress(ifsPad7401("ADDRESS", "VARCHAR", info.getAddress()));
				ifs7401.setTel(ifsPad7401("TEL", "VARCHAR", info.getTel()));
				ifs7401.setHospCode(hospCode);
				ifs7401.setFkphy7401(pk);
				ifs7401.setIfFlag("10");
			}
			
			String ifs7401SeqStr = commonRepository.getNextVal("IFS7401_SEQ");
			Double ifs7401Seq = CommonUtils.parseDouble(ifs7401SeqStr);
			ifs7401.setPkifs7401(ifs7401Seq);
			
			ifs7401Repository.save(ifs7401);
			
			oErr = "0";
			response.setRtnIfsCnt(oErr);
			return response.build();
	}
	
	public String ifsPad7401(String column, String dataType, String value){
		return fnIfsPad(column, dataType, value, mapIfs7401, configuration.getSchema()+":IFS7401");
	}
}
