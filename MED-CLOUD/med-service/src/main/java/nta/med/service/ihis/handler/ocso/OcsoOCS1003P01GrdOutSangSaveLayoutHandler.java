package nta.med.service.ihis.handler.ocso;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.out.Outsang;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OcsoOCS1003P01GrdOutSangSaveLayoutHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GrdOutSangSaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(OcsoOCS1003P01GrdOutSangSaveLayoutHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GrdOutSangSaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response = saveLayOut(request, getHospitalCode(vertx, sessionId));
    	if(!response.getResult()){
    		throw new ExecutionException(response.build());
    	}
		return response.build();
	}
	public SystemServiceProto.UpdateResponse.Builder saveLayOut(OcsoServiceProto.OcsoOCS1003P01GrdOutSangSaveLayoutRequest request, String hospCode){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		List<OcsoModelProto.OcsoOCS1003P01GridOutSangInfo> lstOutSang = request.getGrdOutSangListList();
		if(lstOutSang != null && lstOutSang.size() > 0){
			for(OcsoModelProto.OcsoOCS1003P01GridOutSangInfo outSangInfo : lstOutSang){
			
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(outSangInfo.getDataRowState())){
					Double pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,outSangInfo.getBunho(),outSangInfo.getGwa(),outSangInfo.getIoGubun());
					if(pkSeq == null){
						pkSeq = 1.0;
					}
					Double ser = outsangRepository.getOUTSANGU00Ser(hospCode, outSangInfo.getBunho());
					if(ser == null){
						ser = 1.0;
					}
					String resultSang = outsangRepository.getOUTSANGU00ResultSang(hospCode,outSangInfo.getIoGubun(), outSangInfo.getGwa(),
							outSangInfo.getBunho(), outSangInfo.getFkinp1001(), outSangInfo.getSangCode(),outSangInfo.getSangName(), outSangInfo.getPostModifierName(),
							outSangInfo.getPreModifierName(),outSangInfo.getSangStartDate(),outSangInfo.getSangEndDate(),outSangInfo.getSangJindanDate(),
							outSangInfo.getDataGubun(),outSangInfo.getJuSangYn());
					if(resultSang.equalsIgnoreCase("Y")){
						response.setResult(false);
						return response;
					}
					Outsang outsang = new Outsang();
					
					outsang.setSysDate(new Date());
					outsang.setSysId(request.getUserId());
					outsang.setBunho(outSangInfo.getBunho());
					outsang.setHospCode(hospCode);
					outsang.setGwa(outSangInfo.getGwa());
					outsang.setIoGubun(outSangInfo.getIoGubun()); 
					outsang.setPkSeq(pkSeq);
					if(!outSangInfo.getNaewonDate().isEmpty() && DateUtil.toDate(outSangInfo.getNaewonDate(),DateUtil.PATTERN_YYMMDD) != null){
						outsang.setNaewonDate(DateUtil.toDate(outSangInfo.getNaewonDate(),DateUtil.PATTERN_YYMMDD)); 
					}

					outsang.setDoctor(outSangInfo.getLastDoctor());
					outsang.setNaewonType(outSangInfo.getLastNaewonType());
					if(outSangInfo.getJubsuNo()!= null && !outSangInfo.getJubsuNo().isEmpty() ){
						outsang.setJubsuNo(CommonUtils.parseDouble(outSangInfo.getJubsuNo()));
					}
					if(outSangInfo.getNaewonDate() != null && !outSangInfo.getNaewonDate().isEmpty()){
						outsang.setLastNaewonDate (DateUtil.toDate(outSangInfo.getNaewonDate(),DateUtil.PATTERN_YYMMDD)); 
					}
					outsang.setLastDoctor(outSangInfo.getLastDoctor());
					outsang.setLastNaewonType(outSangInfo.getLastNaewonType());
					if(outSangInfo.getLastJubsuNo()!= null && !outSangInfo.getLastJubsuNo().isEmpty() ){
						outsang.setLastJubsuNo(CommonUtils.parseDouble(outSangInfo.getLastJubsuNo()));
					}
					if(outSangInfo.getFkinp1001()!= null && !outSangInfo.getFkinp1001().isEmpty() ){
						outsang.setFkinp1001(CommonUtils.parseDouble(outSangInfo.getFkinp1001()));
					}
					outsang.setInputId(request.getUserId());
					outsang.setSer(ser);
					outsang.setSangCode(outSangInfo.getSangCode());
					outsang.setJuSangYn(outSangInfo.getJuSangYn());
					outsang.setSangName (outSangInfo.getSangName());
					if(!outSangInfo.getSangStartDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangStartDate(),DateUtil.PATTERN_YYMMDD) != null){
						outsang.setSangStartDate (DateUtil.toDate(outSangInfo.getSangStartDate(),DateUtil.PATTERN_YYMMDD)); 
					}
					if(!outSangInfo.getSangEndDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangEndDate(),DateUtil.PATTERN_YYMMDD) != null){
						outsang.setSangEndDate (DateUtil.toDate(outSangInfo.getSangEndDate(),DateUtil.PATTERN_YYMMDD)); 
					}
					outsang.setSangEndSayu(outSangInfo.getSangEndSayu());
					outsang.setPreModifier1 (outSangInfo.getPreModifier1());
					outsang.setPreModifier2(outSangInfo.getPreModifier2());
					outsang.setPreModifier3(outSangInfo.getPreModifier3());
					outsang.setPreModifier4(outSangInfo.getPreModifier4());
					outsang.setPreModifier5 (outSangInfo.getPreModifier5());
					outsang.setPreModifier6(outSangInfo.getPreModifier6());
					outsang.setPreModifier7(outSangInfo.getPreModifier7());
					outsang.setPreModifier8(outSangInfo.getPreModifier8());
					outsang.setPreModifier9 (outSangInfo.getPreModifier9());
					outsang.setPreModifier10(outSangInfo.getPreModifier10());
					outsang.setPreModifierName(outSangInfo.getPreModifierName());
					outsang.setPostModifier1(outSangInfo.getPostModifier1());
					outsang.setPostModifier2(outSangInfo.getPostModifier2());
					outsang.setPostModifier3(outSangInfo.getPostModifier3());
					outsang.setPostModifier4(outSangInfo.getPostModifier4());
					outsang.setPostModifier5(outSangInfo.getPostModifier5());
					outsang.setPostModifier6(outSangInfo.getPostModifier6());
					outsang.setPostModifier7(outSangInfo.getPostModifier7());
					outsang.setPostModifier8(outSangInfo.getPostModifier8());
					outsang.setPostModifier9(outSangInfo.getPostModifier9());
					outsang.setPostModifier10(outSangInfo.getPostModifier10());
					outsang.setPostModifierName(outSangInfo.getPostModifierName());
					if(!outSangInfo.getSangJindanDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangJindanDate(),DateUtil.PATTERN_YYMMDD) != null){
						outsang.setSangJindanDate (DateUtil.toDate(outSangInfo.getSangJindanDate(),DateUtil.PATTERN_YYMMDD)); 
					}
					outsang.setDataGubun(outSangInfo.getDataGubun());
					outsangRepository.save(outsang);
					
					 //IF modified
				} else if (DataRowState.MODIFIED.getValue().equalsIgnoreCase(outSangInfo.getDataRowState())){
					Double pkoutsang = CommonUtils.parseDouble(outSangInfo.getPkoutsang());
					String retVal = outsangRepository.getOcsoOCS1003P01GetGwoFromOutsang(hospCode, pkoutsang);
					Double ser = 0.0;
					Double pkSeq = 0.0;
					if(outSangInfo.getSer() != null && !outSangInfo.getSer().isEmpty()){
						ser = CommonUtils.parseDouble(outSangInfo.getSer());
					}
					if(outSangInfo.getPkSeq() != null && !outSangInfo.getPkSeq().isEmpty()){
						pkSeq = CommonUtils.parseDouble(outSangInfo.getPkSeq());
					}
					
					if("%".equals(retVal)){
						pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,outSangInfo.getBunho(),outSangInfo.getGwa(),outSangInfo.getIoGubun());
						if(pkSeq == null){
							pkSeq = 1.0;
						}
						ser = outsangRepository.getOUTSANGU00Ser(hospCode, outSangInfo.getBunho());
						if(ser == null){
							ser = 1.0;
						}
					}
					
					String resultSang = outsangRepository.getOUTSANGU00ResultSang(hospCode,outSangInfo.getIoGubun(), outSangInfo.getGwa(),
							outSangInfo.getBunho(), outSangInfo.getFkinp1001(), outSangInfo.getSangCode(),outSangInfo.getSangName(), outSangInfo.getPostModifierName(),
							outSangInfo.getPreModifierName(),outSangInfo.getSangStartDate(),outSangInfo.getSangEndDate(),outSangInfo.getSangJindanDate(),
							outSangInfo.getDataGubun(),outSangInfo.getJuSangYn());
					if(resultSang.equalsIgnoreCase("Y")){
						response.setResult(false);
						return response;
					}
					
					
					Date sangStartDate = new Date();
					Date sangEndDate = new Date();
					Date sangJindanDate = new Date();
					if(!outSangInfo.getSangStartDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangStartDate(), DateUtil.PATTERN_YYMMDD) != null){
						sangStartDate = DateUtil.toDate(outSangInfo.getSangStartDate(), DateUtil.PATTERN_YYMMDD);
					}
					if(!outSangInfo.getSangEndDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangEndDate(), DateUtil.PATTERN_YYMMDD) != null){
						sangEndDate = DateUtil.toDate(outSangInfo.getSangEndDate(), DateUtil.PATTERN_YYMMDD);
					}
					if(!outSangInfo.getSangJindanDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangJindanDate(), DateUtil.PATTERN_YYMMDD) != null){
						sangJindanDate = DateUtil.toDate(outSangInfo.getSangJindanDate(), DateUtil.PATTERN_YYMMDD);
					}
					outsangRepository.updateOUTSANGOU00Transaction(request.getUserId(), 
							ser, 
							outSangInfo.getSangName(), 
							sangStartDate, 
							sangEndDate, 
							outSangInfo.getSangEndSayu(), 
							outSangInfo.getJuSangYn(),
							outSangInfo.getPreModifier1(), 
							outSangInfo.getPreModifier2(), 
							outSangInfo.getPreModifier3(), 
							outSangInfo.getPreModifier4(), 
							outSangInfo.getPreModifier5(), 
							outSangInfo.getPreModifier6(), 
							outSangInfo.getPreModifier7(), 
							outSangInfo.getPreModifier8(), 
							outSangInfo.getPreModifier9(), 
							outSangInfo.getPreModifier10(), 
							outSangInfo.getPreModifierName(), 
							outSangInfo.getPostModifier1(), 
							outSangInfo.getPostModifier2(), 
							outSangInfo.getPostModifier3(), 
							outSangInfo.getPostModifier4(), 
							outSangInfo.getPostModifier5(), 
							outSangInfo.getPostModifier6(), 
							outSangInfo.getPostModifier7(), 
							outSangInfo.getPostModifier8(), 
							outSangInfo.getPostModifier9(), 
							outSangInfo.getPostModifier10(), 
							outSangInfo.getPostModifierName(), 
							sangJindanDate, 
							outSangInfo.getDataGubun(), 
							outSangInfo.getBunho(), 
							outSangInfo.getGwa(), 
							outSangInfo.getIoGubun(), 
							pkSeq, 
							hospCode);
				} else if (DataRowState.DELETED.getValue().equals(outSangInfo.getDataRowState())){
						String ifDataSendYn = outsangRepository.getIfDataSendYn(hospCode, outSangInfo.getBunho(), outSangInfo.getGwa(), outSangInfo.getIoGubun(), CommonUtils.parseDouble(outSangInfo.getPkSeq()));
						
						if(outSangInfo.getDataGubun().equalsIgnoreCase("I") && ifDataSendYn.equalsIgnoreCase("N")){
							Double pkSeq = 0.0;
							if(outSangInfo.getPkSeq() != null && !outSangInfo.getPkSeq().isEmpty()){
								pkSeq = CommonUtils.parseDouble(outSangInfo.getPkSeq());
							}
							outsangRepository.deleteOUTSANGU00Transaction(
									outSangInfo.getBunho(),
									outSangInfo.getGwa(),
									outSangInfo.getIoGubun(),
									pkSeq,
									hospCode);
						}else{
							Double pkoutsang = CommonUtils.parseDouble(outSangInfo.getPkoutsang());
							String retVal = outsangRepository.getOcsoOCS1003P01GetGwoFromOutsang(hospCode, pkoutsang);
							Double ser = 0.0;
							Double pkSeq = 0.0;
							if(outSangInfo.getSer() != null && !outSangInfo.getSer().isEmpty()){
								ser = CommonUtils.parseDouble(outSangInfo.getSer());
							}
							if(outSangInfo.getPkSeq() != null && !outSangInfo.getPkSeq().isEmpty()){
								pkSeq = CommonUtils.parseDouble(outSangInfo.getPkSeq());
							}
							
							if("%".equals(retVal)){
								pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,outSangInfo.getBunho(),outSangInfo.getGwa(),outSangInfo.getIoGubun());
								if(pkSeq == null){
									pkSeq = 1.0;
								}
								ser = outsangRepository.getOUTSANGU00Ser(hospCode, outSangInfo.getBunho());
								if(ser == null){
									ser = 1.0;
								}
							}
							
							Date sangStartDate = new Date();
							Date sangEndDate = new Date();
							Date sangJindanDate = new Date();
							if(!outSangInfo.getSangStartDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangStartDate(), DateUtil.PATTERN_YYMMDD) != null){
								sangStartDate = DateUtil.toDate(outSangInfo.getSangStartDate(), DateUtil.PATTERN_YYMMDD);
							}
							if(!outSangInfo.getSangEndDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangEndDate(), DateUtil.PATTERN_YYMMDD) != null){
								sangEndDate = DateUtil.toDate(outSangInfo.getSangEndDate(), DateUtil.PATTERN_YYMMDD);
							}
							if(!outSangInfo.getSangJindanDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangJindanDate(), DateUtil.PATTERN_YYMMDD) != null){
								sangJindanDate = DateUtil.toDate(outSangInfo.getSangJindanDate(), DateUtil.PATTERN_YYMMDD);
							}
							outsangRepository.updateOUTSANGOU00Transaction(request.getUserId(), 
									ser, 
									outSangInfo.getSangName(), 
									sangStartDate, 
									sangEndDate, 
									outSangInfo.getSangEndSayu(), 
									outSangInfo.getJuSangYn(),
									outSangInfo.getPreModifier1(), 
									outSangInfo.getPreModifier2(), 
									outSangInfo.getPreModifier3(), 
									outSangInfo.getPreModifier4(), 
									outSangInfo.getPreModifier5(), 
									outSangInfo.getPreModifier6(), 
									outSangInfo.getPreModifier7(), 
									outSangInfo.getPreModifier8(), 
									outSangInfo.getPreModifier9(), 
									outSangInfo.getPreModifier10(), 
									outSangInfo.getPreModifierName(), 
									outSangInfo.getPostModifier1(), 
									outSangInfo.getPostModifier2(), 
									outSangInfo.getPostModifier3(), 
									outSangInfo.getPostModifier4(), 
									outSangInfo.getPostModifier5(), 
									outSangInfo.getPostModifier6(), 
									outSangInfo.getPostModifier7(), 
									outSangInfo.getPostModifier8(), 
									outSangInfo.getPostModifier9(), 
									outSangInfo.getPostModifier10(), 
									outSangInfo.getPostModifierName(), 
									sangJindanDate, 
									outSangInfo.getDataGubun(), 
									outSangInfo.getBunho(), 
									outSangInfo.getGwa(), 
									outSangInfo.getIoGubun(), 
									pkSeq, 
									hospCode);
						}
				}
			}
		}
		
		response.setResult(true);
		return response;
	}

}
