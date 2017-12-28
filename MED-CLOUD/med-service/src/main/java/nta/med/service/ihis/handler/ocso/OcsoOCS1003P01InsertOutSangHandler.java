package nta.med.service.ihis.handler.ocso;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.out.Outsang;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OcsoOCS1003P01InsertOutSangHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01InsertOutSangRequest, SystemServiceProto.UpdateResponse>{
	private static final Log logger = LogFactory.getLog(OcsoOCS1003P01InsertOutSangHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01InsertOutSangRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = insertOutSang(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
	private boolean insertOutSang(OcsoServiceProto.OcsoOCS1003P01InsertOutSangRequest request, String hospCode) {
			Outsang outsang = new Outsang();
			outsang.setSysDate(new Date());
			if(!StringUtils.isEmpty(request.getSysId())) {
				outsang.setSysId(request.getSysId());
			}
			outsang.setUpdDate(new Date());
			if(!StringUtils.isEmpty(request.getBunho())) {
				outsang.setBunho(request.getBunho());
			}
			if(!StringUtils.isEmpty(request.getGwa())) {
				outsang.setGwa(request.getGwa());
			}
			if(!StringUtils.isEmpty(request.getIoGubun())) {
				outsang.setIoGubun(request.getIoGubun());
			}
			if(!StringUtils.isEmpty(request.getPkSeq())) {
				Double pkSeq = CommonUtils.parseDouble(request.getPkSeq());
				outsang.setPkSeq(pkSeq);
			}
			if(!StringUtils.isEmpty(request.getNaewonDate())) {
				Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
				outsang.setNaewonDate(naewonDate);
			}
			if(!StringUtils.isEmpty(request.getDoctor())) {
				outsang.setDoctor(request.getDoctor());
			}
			if(!StringUtils.isEmpty(request.getNaewonType())) {
				outsang.setNaewonType(request.getNaewonType());
			}
			if(!StringUtils.isEmpty(request.getJubsuNo())) {
				Double jubsuNo = CommonUtils.parseDouble(request.getJubsuNo());
				outsang.setJubsuNo(jubsuNo);
			}
			if(!StringUtils.isEmpty(request.getLastNaewonDate())) {
				Date lastNaewonDate = DateUtil.toDate(request.getLastNaewonDate(), DateUtil.PATTERN_YYMMDD);
				outsang.setLastNaewonDate(lastNaewonDate);
			}
			if(!StringUtils.isEmpty(request.getLastDoctor())) {
				outsang.setLastDoctor(request.getLastDoctor());
			}
			if(!StringUtils.isEmpty(request.getLastNaewonType())) {
				outsang.setLastNaewonType(request.getLastNaewonType());
			}
			if(!StringUtils.isEmpty(request.getLastJubsuNo())) {
				Double lastJubsuNo = CommonUtils.parseDouble(request.getLastJubsuNo());
				outsang.setLastJubsuNo(lastJubsuNo);
			}
			if(!StringUtils.isEmpty(request.getFkinp1001())) {
				Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
				outsang.setFkinp1001(fkinp1001);
			}
			if(!StringUtils.isEmpty(request.getInputId())) {
				outsang.setInputId(request.getInputId());
			}
			if(!StringUtils.isEmpty(request.getSer())) {
				Double ser = CommonUtils.parseDouble(request.getSer());
				outsang.setSer(ser);
			}
			if(!StringUtils.isEmpty(request.getSangCode())) {
				outsang.setSangCode(request.getSangCode());
			}
			if(!StringUtils.isEmpty(request.getJuSangYn())) {
				outsang.setJuSangYn(request.getJuSangYn());
			}
			if(!StringUtils.isEmpty(request.getSangName())) {
				outsang.setSangName(request.getSangName());
			}
			if(!StringUtils.isEmpty(request.getSangStartDate())) {
				Date sangStartDate = DateUtil.toDate(request.getSangStartDate(), DateUtil.PATTERN_YYMMDD);
				outsang.setSangStartDate(sangStartDate);
			}
			if(!StringUtils.isEmpty(request.getSangEndDate())) {
				Date sangEndDate = DateUtil.toDate(request.getSangEndDate(), DateUtil.PATTERN_YYMMDD);
				outsang.setSangEndDate(sangEndDate);
			}
			if(!StringUtils.isEmpty(request.getSangEndSayu())) {
				outsang.setSangEndSayu(request.getSangEndSayu());
			}
			if(!StringUtils.isEmpty(request.getPreModifier1())) {
				outsang.setPreModifier1(request.getPreModifier1());
			}
			if(!StringUtils.isEmpty(request.getPreModifier2())) {
				outsang.setPreModifier2(request.getPreModifier2());
			}
			if(!StringUtils.isEmpty(request.getPreModifier3())) {
				outsang.setPreModifier3(request.getPreModifier3());
			}
			if(!StringUtils.isEmpty(request.getPreModifier4())) {
				outsang.setPreModifier4(request.getPreModifier4());
			}
			if(!StringUtils.isEmpty(request.getPreModifier5())) {
				outsang.setPreModifier5(request.getPreModifier5());
			}
			if(!StringUtils.isEmpty(request.getPreModifier6())) {
				outsang.setPreModifier6(request.getPreModifier6());
			}
			if(!StringUtils.isEmpty(request.getPreModifier7())) {
				outsang.setPreModifier7(request.getPreModifier7());
			}
			if(!StringUtils.isEmpty(request.getPreModifier8())) {
				outsang.setPreModifier8(request.getPreModifier8());
			}
			if(!StringUtils.isEmpty(request.getPreModifier9())) {
				outsang.setPreModifier9(request.getPreModifier9());
			}
			if(!StringUtils.isEmpty(request.getPreModifier10())) {
				outsang.setPreModifier10(request.getPreModifier10());
			}
			if(!StringUtils.isEmpty(request.getPreModifierName())) {
				outsang.setPreModifierName(request.getPreModifierName());
			}
			if(!StringUtils.isEmpty(request.getPostModifier1())) {
				outsang.setPostModifier1(request.getPostModifier1());
			}
			if(!StringUtils.isEmpty(request.getPostModifier2())) {
				outsang.setPostModifier2(request.getPostModifier2());
			}
			if(!StringUtils.isEmpty(request.getPostModifier3())) {
				outsang.setPostModifier3(request.getPostModifier3());
			}
			if(!StringUtils.isEmpty(request.getPostModifier4())) {
				outsang.setPostModifier4(request.getPostModifier4());
			}
			if(!StringUtils.isEmpty(request.getPostModifier5())) {
				outsang.setPostModifier5(request.getPostModifier5());
			}
			if(!StringUtils.isEmpty(request.getPostModifier6())) {
				outsang.setPostModifier6(request.getPostModifier6());
			}
			if(!StringUtils.isEmpty(request.getPostModifier7())) {
				outsang.setPostModifier7(request.getPostModifier7());
			}
			if(!StringUtils.isEmpty(request.getPostModifier8())) {
				outsang.setPostModifier8(request.getPostModifier8());
			}
			if(!StringUtils.isEmpty(request.getPostModifier9())) {
				outsang.setPostModifier9(request.getPostModifier9());
			}
			if(!StringUtils.isEmpty(request.getPostModifier10())) {
				outsang.setPostModifier10(request.getPostModifier10());
			}
			if(!StringUtils.isEmpty(request.getPostModifierName())) {
				outsang.setPostModifierName(request.getPostModifierName());
			}
			outsang.setHospCode(hospCode);
			if(!StringUtils.isEmpty(request.getUpdId())) {
				outsang.setUpdId(request.getUpdId());
			}
			if(!StringUtils.isEmpty(request.getFkout1001())) {
				Double fkout1001 = CommonUtils.parseDouble(request.getFkout1001());
				outsang.setFkout1001(fkout1001);
			}
			if(!StringUtils.isEmpty(request.getSangJindanDate())) {
				Date sangJindanDate = DateUtil.toDate(request.getSangJindanDate(), DateUtil.PATTERN_YYMMDD);
				outsang.setSangJindanDate(sangJindanDate);
			}
			if(!StringUtils.isEmpty(request.getDataGubun())) {
				outsang.setDataGubun(request.getDataGubun());
			}
			
			outsangRepository.save(outsang);
			return true;
	}
	
}
