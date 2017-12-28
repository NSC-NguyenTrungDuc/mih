package nta.med.service.ihis.handler.phys;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.phy.Phy8002;
import nta.med.core.domain.phy.Phy8003;
import nta.med.core.domain.phy.Phy8004;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.phy.Phy8002Repository;
import nta.med.data.dao.medi.phy.Phy8003Repository;
import nta.med.data.dao.medi.phy.Phy8004Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U00GrdPHYRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U00GrdPHYResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U00GrdPHYHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U00GrdPHYRequest, PhysServiceProto.PHY8002U00GrdPHYResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(PHY8002U00GrdPHYHandler.class);                                    
	@Resource                                                                                                       
	private Phy8002Repository phy8002Repository;                                                                    
	@Resource                                                                                                       
	private Phy8003Repository phy8003Repository;                                                                    
	@Resource                                                                                                       
	private Phy8004Repository phy8004Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly=true)
	public PHY8002U00GrdPHYResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY8002U00GrdPHYRequest request)
			throws Exception {                                                                   
  	   	PhysServiceProto.PHY8002U00GrdPHYResponse.Builder response = PhysServiceProto.PHY8002U00GrdPHYResponse.newBuilder();    
  	    String hospCode = getHospitalCode(vertx, sessionId);
		if (!StringUtils.isEmpty(request.getFkOcs())) {
			getPHY8002(hospCode, request.getFkOcs(), response);
			if(!CollectionUtils.isEmpty(response.getGrd8002InfoBuilderList())) {
				LOGGER.info("[START] search Phy8003, Phy8004");
				PhysModelProto.PHY8002U00GrdPHY8002Info.Builder phy8002Info =  response.getGrd8002InfoBuilderList().get(0);
				getPhy8003(hospCode, request.getKanjaNo(), phy8002Info.getPkphy8002(), response);
				getPhy8004(hospCode, phy8002Info.getPkphy8002(), response);
			}
		}
		return response.build();
	}

	private void getPhy8004(String hospCode, String fkOcsIrai,
			PhysServiceProto.PHY8002U00GrdPHYResponse.Builder response) {
		List<Phy8004> listItem = phy8004Repository.getByFkOcsIrai(hospCode, CommonUtils.parseDouble(fkOcsIrai));
		if (!CollectionUtils.isEmpty(listItem)) {
			for (Phy8004 item : listItem) {
				PhysModelProto.PHY8002U00GrdPHY8004Info.Builder info = PhysModelProto.PHY8002U00GrdPHY8004Info.newBuilder();
				if (!StringUtils.isEmpty(item.getDataKubun())) {
					info.setDataKubun(item.getDataKubun());
				}
				if (item.getFkOcsIrai() != null) {
					info.setFkOcsIrai(item.getFkOcsIrai().toString());
				}
				if (item.getFkcht0113() != null) {
					info.setFkcht0113(item.getFkcht0113().toString());
				}
				if (!StringUtils.isEmpty(item.getHospCode())) {
					info.setHospCode(item.getHospCode());
				}
				if (!StringUtils.isEmpty(item.getKanjaNo())) {
					info.setKanjaNo(item.getKanjaNo());
				}
				if (item.getPkPhySyougai() != null) {
					info.setPkPhySyougai(item.getPkPhySyougai().toString());
				}
				if (!StringUtils.isEmpty(item.getSyougaiId())) {
					info.setSyougaiId(item.getSyougaiId());
				}
				if (!StringUtils.isEmpty(item.getSyougaimei())) {
					info.setSyougaimei(item.getSyougaimei());
				}
				if (item.getSysDate() != null) {
					info.setSysDate(DateUtil.toString(item.getSysDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (item.getUpdDate() != null) {
					info.setUpdDate(DateUtil.toString(item.getUpdDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(item.getUserId())) {
					info.setUserId(item.getUserId());
				}

				response.addGrd8004Info(info);
			}
		}
	}

	private void getPhy8003(String hospCode, String kanjaNo, String fkOcsIrai,
			PhysServiceProto.PHY8002U00GrdPHYResponse.Builder response) {
		List<Phy8003> listItem = phy8003Repository.getByKanjaNoAndFkOcsIrai(hospCode, kanjaNo, CommonUtils.parseDouble(fkOcsIrai));
		if (!CollectionUtils.isEmpty(listItem)) {
			for (Phy8003 item : listItem) {
				PhysModelProto.PHY8002U00GrdPHY8003Info.Builder info = PhysModelProto.PHY8002U00GrdPHY8003Info.newBuilder();
				if (!StringUtils.isEmpty(item.getDataKubun())) {
					info.setDataKubun(item.getDataKubun());
				}
				if (item.getFkOcsIrai() != null) {
					info.setFkOcsIrai(item.getFkOcsIrai().toString());
				}
				if (item.getFkoutsang() != null) {
					info.setFkoutsang(item.getFkoutsang().toString());
				}
				if (!StringUtils.isEmpty(item.getHassyoubi())) {
					info.setHassyoubi(item.getHassyoubi());
				}
				if (!StringUtils.isEmpty(item.getHospCode())) {
					info.setHospCode(item.getHospCode());
				}
				if (!StringUtils.isEmpty(item.getIoKubun())) {
					info.setIoKubun(item.getIoKubun());
				}
				if (!StringUtils.isEmpty(item.getIraiDate())) {
					info.setIraiDate(item.getIraiDate());
				}
				if (!StringUtils.isEmpty(item.getKanjaNo())) {
					info.setKanjaNo(item.getKanjaNo());
				}
				if (item.getPkPhySyoubyou() != null) {
					info.setPkPhySyoubyou(item.getPkPhySyoubyou().toString());
				}
				if (!StringUtils.isEmpty(item.getPostModifierName())) {
					info.setPostModifierName(item.getPostModifierName());
				}
				if (!StringUtils.isEmpty(item.getPostModifier1())) {
					info.setPostModifier1(item.getPostModifier1());
				}
				if (!StringUtils.isEmpty(item.getPostModifier10())) {
					info.setPostModifier10(item.getPostModifier10());
				}
				if (!StringUtils.isEmpty(item.getPostModifier2())) {
					info.setPostModifier2(item.getPostModifier2());
				}
				if (!StringUtils.isEmpty(item.getPostModifier3())) {
					info.setPostModifier3(item.getPostModifier3());
				}
				if (!StringUtils.isEmpty(item.getPostModifier4())) {
					info.setPostModifier4(item.getPostModifier4());
				}
				if (!StringUtils.isEmpty(item.getPostModifier5())) {
					info.setPostModifier5(item.getPostModifier5());
				}
				if (!StringUtils.isEmpty(item.getPostModifier6())) {
					info.setPostModifier6(item.getPostModifier6());
				}
				if (!StringUtils.isEmpty(item.getPostModifier7())) {
					info.setPostModifier7(item.getPostModifier7());
				}
				if (!StringUtils.isEmpty(item.getPostModifier8())) {
					info.setPostModifier8(item.getPostModifier8());
				}
				if (!StringUtils.isEmpty(item.getPostModifier9())) {
					info.setPostModifier9(item.getPostModifier9());
				}
				if (!StringUtils.isEmpty(item.getPreModifierName())) {
					info.setPreModifierName(item.getPreModifierName());
				}
				if (!StringUtils.isEmpty(item.getPreModifier1())) {
					info.setPreModifier1(item.getPreModifier1());
				}
				if (!StringUtils.isEmpty(item.getPreModifier10())) {
					info.setPreModifier10(item.getPreModifier10());
				}
				if (!StringUtils.isEmpty(item.getPreModifier2())) {
					info.setPreModifier2(item.getPreModifier2());
				}
				if (!StringUtils.isEmpty(item.getPreModifier3())) {
					info.setPreModifier3(item.getPreModifier3());
				}
				if (!StringUtils.isEmpty(item.getPreModifier4())) {
					info.setPreModifier4(item.getPreModifier4());
				}
				if (!StringUtils.isEmpty(item.getPreModifier5())) {
					info.setPreModifier5(item.getPreModifier5());
				}
				if (!StringUtils.isEmpty(item.getPreModifier6())) {
					info.setPreModifier6(item.getPreModifier6());
				}
				if (!StringUtils.isEmpty(item.getPreModifier7())) {
					info.setPreModifier7(item.getPreModifier7());
				}
				if (!StringUtils.isEmpty(item.getPreModifier8())) {
					info.setPreModifier8(item.getPreModifier8());
				}
				if (!StringUtils.isEmpty(item.getPreModifier9())) {
					info.setPreModifier9(item.getPreModifier9());
				}
				if (!StringUtils.isEmpty(item.getSindanbi())) {
					info.setSindanbi(item.getSindanbi());
				}
				if (!StringUtils.isEmpty(item.getSinryouka())) {
					info.setSinryouka(item.getSinryouka());
				}
				if (!StringUtils.isEmpty(item.getSyoubyoumei())) {
					info.setSyoubyoumei(item.getSyoubyoumei());
				}
				if (!StringUtils.isEmpty(item.getSyoubyoumeiCode())) {
					info.setSyoubyoumeiCode(item.getSyoubyoumeiCode());
				}
				if (item.getSysDate() != null) {
					info.setSysDate(DateUtil.toString(item.getSysDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (item.getUpdDate() != null) {
					info.setUpdDate(DateUtil.toString(item.getUpdDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(item.getUserId())) {
					info.setUserId(item.getUserId());
				}
				info.setModifierName(item.getPreModifierName() + item.getSyoubyoumei() + item.getPostModifierName());
				
				response.addGrd8003Info(info);
			}
		}
	}

	private void getPHY8002(String hospCode, String fkOcs,
			PhysServiceProto.PHY8002U00GrdPHYResponse.Builder response) {
		List<Phy8002> listItem = phy8002Repository.getByFkOcs(hospCode, CommonUtils.parseDouble(fkOcs));
		if (!CollectionUtils.isEmpty(listItem)) {
			for (Phy8002 item : listItem) {
				PhysModelProto.PHY8002U00GrdPHY8002Info.Builder info = PhysModelProto.PHY8002U00GrdPHY8002Info.newBuilder();
				if (!StringUtils.isEmpty(item.getBuFlag())) {
					info.setBuFlag(item.getBuFlag());
				}
				if (!StringUtils.isEmpty(item.getByousituCode())) {
					info.setByousituCode(item.getByousituCode());
				}
				if (!StringUtils.isEmpty(item.getByoutouCode())) {
					info.setByoutouCode(item.getByoutouCode());
				}
				if (!StringUtils.isEmpty(item.getComplications())) {
					info.setComplications(item.getComplications());
				}
				if (!StringUtils.isEmpty(item.getConsultComment())) {
					info.setConsultComment(item.getConsultComment());
				}
				if (item.getCrTime() != null) {
					info.setCrTime(DateUtil.toString(item.getCrTime(), DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS));
				} else {
					info.setCrTime(DateUtil.toString(new Date(), DateUtil.PATTERN_SLASH_YYYYMMDD_HH_COLON_MM_SS));
				}
				if (item.getFkOcs() != null) {
					info.setFkOcs(item.getFkOcs() + "");
				}
				if (!StringUtils.isEmpty(item.getFrequency())) {
					info.setFrequency(item.getFrequency());
				}
				if (!StringUtils.isEmpty(item.getGenbyoureki())) {
					info.setGenbyoureki(item.getGenbyoureki());
				}
				if (!StringUtils.isEmpty(item.getHospCode())) {
					info.setHospCode(item.getHospCode());
				}
				if (!StringUtils.isEmpty(item.getImage())) {
					info.setImage(item.getImage());
				}
				if (!StringUtils.isEmpty(item.getImagePath())) {
					info.setImagePath(item.getImagePath());
				}
				if (item.getImageSeq() != null) {
					info.setImageSeq(item.getImageSeq() + "");
				}
				if (!StringUtils.isEmpty(item.getInfectious())) {
					info.setInfectious(item.getInfectious());
				}
				if (!StringUtils.isEmpty(item.getIoKubun())) {
					info.setIoKubun(item.getIoKubun());
				}
				if (!StringUtils.isEmpty(item.getIraiDate())) {
					info.setIraiDate(item.getIraiDate());
				}
				if (!StringUtils.isEmpty(item.getIraiKubun())) {
					info.setIraiKubun(item.getIraiKubun());
				}
				if (item.getKaisibi() != null) {
					info.setKaisibi(DateUtil.toString(item.getKaisibi(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(item.getKanjaNo())) {
					info.setKanjaNo(item.getKanjaNo());
				}
				if (!StringUtils.isEmpty(item.getKeFlag())) {
					info.setKeFlag(item.getKeFlag());
				}
				if (!StringUtils.isEmpty(item.getKioureki())) {
					info.setKioureki(item.getKioureki());
				}
				if (!StringUtils.isEmpty(item.getKoumokuCode())) {
					info.setKoumokuCode(item.getKoumokuCode());
				}
				if (item.getKyuseizouakubi() != null) {
					info.setKyuseizouakubi(DateUtil.toString(item.getKyuseizouakubi(), DateUtil.PATTERN_YYMMDD));
				}
				if (item.getNissuu() != null) {
					info.setNissuu(item.getNissuu() + "");
				}
				if (!StringUtils.isEmpty(item.getNyuuinnbi())) {
					info.setNyuuinnbi(item.getNyuuinnbi());
				}
				if (!StringUtils.isEmpty(item.getObjective())) {
					info.setObjective(item.getObjective());
				}
				if (!StringUtils.isEmpty(item.getOtFlag())) {
					info.setOtFlag(item.getOtFlag());
				}
				if (!StringUtils.isEmpty(item.getOt1())) {
					info.setOt1(item.getOt1());
				}
				if (!StringUtils.isEmpty(item.getOt10())) {
					info.setOt10(item.getOt10());
				}
				if (!StringUtils.isEmpty(item.getOt2())) {
					info.setOt2(item.getOt2());
				}
				if (!StringUtils.isEmpty(item.getOt3())) {
					info.setOt3(item.getOt3());
				}
				if (!StringUtils.isEmpty(item.getOt4())) {
					info.setOt4(item.getOt4());
				}
				if (!StringUtils.isEmpty(item.getOt5())) {
					info.setOt5(item.getOt5());
				}
				if (!StringUtils.isEmpty(item.getOt6())) {
					info.setOt6(item.getOt6());
				}
				if (!StringUtils.isEmpty(item.getOt7())) {
					info.setOt7(item.getOt7());
				}
				if (!StringUtils.isEmpty(item.getOt8())) {
					info.setOt8(item.getOt8());
				}
				if (!StringUtils.isEmpty(item.getOt9())) {
					info.setOt9(item.getOt9());
				}
				if (item.getPkphy8002() != null) {
					info.setPkphy8002(item.getPkphy8002().toString());
				}
				if (!StringUtils.isEmpty(item.getPtFlag())) {
					info.setPtFlag(item.getPtFlag());
				}
				if (!StringUtils.isEmpty(item.getPt1())) {
					info.setPt1(item.getPt1());
				}
				if (!StringUtils.isEmpty(item.getPt10())) {
					info.setPt10(item.getPt10());
				}
				if (!StringUtils.isEmpty(item.getPt2())) {
					info.setPt2(item.getPt2());
				}
				if (!StringUtils.isEmpty(item.getPt3())) {
					info.setPt3(item.getPt3());
				}
				if (!StringUtils.isEmpty(item.getPt4())) {
					info.setPt4(item.getPt4());
				}
				if (!StringUtils.isEmpty(item.getPt5())) {
					info.setPt5(item.getPt5());
				}
				if (!StringUtils.isEmpty(item.getPt6())) {
					info.setPt6(item.getPt6());
				}
				if (!StringUtils.isEmpty(item.getPt7())) {
					info.setPt7(item.getPt7());
				}
				if (!StringUtils.isEmpty(item.getPt8())) {
					info.setPt8(item.getPt8());
				}
				if (!StringUtils.isEmpty(item.getPt9())) {
					info.setPt9(item.getPt9());
				}
				if (!StringUtils.isEmpty(item.getReha1())) {
					info.setReha1(item.getReha1());
				}
				if (!StringUtils.isEmpty(item.getReha2())) {
					info.setReha2(item.getReha2());
				}
				if (!StringUtils.isEmpty(item.getReha3())) {
					info.setReha3(item.getReha3());
				}
				if (!StringUtils.isEmpty(item.getReha4())) {
					info.setReha4(item.getReha4());
				}
				if (!StringUtils.isEmpty(item.getReha5())) {
					info.setReha5(item.getReha5());
				}
				if (!StringUtils.isEmpty(item.getSindanisi())) {
					info.setSindanisi(item.getSindanisi());
				}
				if (!StringUtils.isEmpty(item.getSinryouka())) {
					info.setSinryouka(item.getSinryouka());
				}
				if (!StringUtils.isEmpty(item.getStFlag())) {
					info.setStFlag(item.getStFlag());
				}
				if (!StringUtils.isEmpty(item.getSt1())) {
					info.setSt1(item.getSt1());
				}
				if (!StringUtils.isEmpty(item.getSt10())) {
					info.setSt10(item.getSt10());
				}
				if (!StringUtils.isEmpty(item.getSt2())) {
					info.setSt2(item.getSt2());
				}
				if (!StringUtils.isEmpty(item.getSt3())) {
					info.setSt3(item.getSt3());
				}
				if (!StringUtils.isEmpty(item.getSt4())) {
					info.setSt4(item.getSt4());
				}
				if (!StringUtils.isEmpty(item.getSt5())) {
					info.setSt5(item.getSt5());
				}
				if (!StringUtils.isEmpty(item.getSt6())) {
					info.setSt6(item.getSt6());
				}
				if (!StringUtils.isEmpty(item.getSt7())) {
					info.setSt7(item.getSt7());
				}
				if (!StringUtils.isEmpty(item.getSt8())) {
					info.setSt8(item.getSt8());
				}
				if (!StringUtils.isEmpty(item.getSt9())) {
					info.setSt9(item.getSt9());
				}
				if (!StringUtils.isEmpty(item.getStopKijyun())) {
					info.setStopKijyun(item.getStopKijyun());
				}
				if (!StringUtils.isEmpty(item.getSu1())) {
					info.setSu1(item.getSu1());
				}
				if (!StringUtils.isEmpty(item.getSu21())) {
					info.setSu21(item.getSu21());
				}
				if (!StringUtils.isEmpty(item.getSu22())) {
					info.setSu22(item.getSu22());
				}
				if (!StringUtils.isEmpty(item.getSu23())) {
					info.setSu23(item.getSu23());
				}
				if (!StringUtils.isEmpty(item.getSu24())) {
					info.setSu24(item.getSu24());
				}
				if (!StringUtils.isEmpty(item.getSu31())) {
					info.setSu31(item.getSu31());
				}
				if (!StringUtils.isEmpty(item.getSu32())) {
					info.setSu32(item.getSu32());
				}
				if (!StringUtils.isEmpty(item.getSu41())) {
					info.setSu41(item.getSu41());
				}
				if (!StringUtils.isEmpty(item.getSu42())) {
					info.setSu42(item.getSu42());
				}
				if (!StringUtils.isEmpty(item.getSu43())) {
					info.setSu43(item.getSu43());
				}
				if (!StringUtils.isEmpty(item.getSyoriFlag())) {
					info.setSyoriFlag(item.getSyoriFlag());
				}
				if (item.getSysDate() != null) {
					info.setSysDate(DateUtil.toString(item.getSysDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (item.getSyujyutubi() != null) {
					info.setSyujyutubi(DateUtil.toString(item.getSyujyutubi(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(item.getTaboo())) {
					info.setTaboo(item.getTaboo());
				}
				if (!StringUtils.isEmpty(item.getTantoui())) {
					info.setTantoui(item.getTantoui());
				}
				if (item.getUpdDate() != null) {
					info.setUpdDate(DateUtil.toString(item.getUpdDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(item.getUserId())) {
					info.setUserId(item.getUserId());
				}
				
				response.addGrd8002Info(info);
			}
		}
	}

}