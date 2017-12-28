package nta.med.service.ihis.handler.bass;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0101;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.MaxSequence;
import nta.med.core.glossary.SeqName;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0101Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.service.ihis.proto.BassModelProto.BAS0101U04GrdDetailInfo;
import nta.med.service.ihis.proto.BassModelProto.BAS0101U04GrdMasterInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U04SaveLayoutRequest;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class BAS0101U04SaveLayoutHandler extends ScreenHandler<BassServiceProto.BAS0101U04SaveLayoutRequest, SystemServiceProto.UpdateResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(BAS0101U04SaveLayoutHandler.class);    
	
	@Resource                                                                                                       
	private Bas0101Repository bas0101Repository;
	
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0101U04SaveLayoutRequest request) throws Exception {                                                                   
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(true);

		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<BAS0101U04GrdMasterInfo> listGroupItem = request.getGrdMasterInfoList();
		
		if(!CollectionUtils.isEmpty(listGroupItem)){
			for(BAS0101U04GrdMasterInfo item : listGroupItem){
				if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					String tChk = bas0101Repository.checkExitsByCodeType(item.getCodeType(), language);
					if("Y".equalsIgnoreCase(tChk)){
						response.setResult(false);
						return response.build();
					}

					Bas0101 bas0101 = new Bas0101();
					bas0101.setSysDate(new Date());
					bas0101.setSysId(request.getUserId());
					bas0101.setUpdDate(new Date());
					bas0101.setUpdId(request.getUserId());
					bas0101.setCodeType(item.getCodeType());
					bas0101.setCodeTypeName(item.getCodeTypeName());
					bas0101.setLanguage(language);
					bas0101.setAdminGubun(item.getAdminGubun());

					bas0101Repository.save(bas0101);
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(bas0101Repository.updateBAS0101U04XSavePerformer(request.getUserId(), new Date(), item.getCodeTypeName(),
							item.getAdminGubun(), item.getCodeType(), language) <= 0){
						response.setResult(false);
						break;

					}
				} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					String tChk = bas0102Repository.checkExitsByCodeType(hospitalCode, item.getCodeType(), language);
					if("Y".equalsIgnoreCase(tChk)){
						response.setResult(false);
						break;
					}
					if(bas0101Repository.deleteBas0101U00TransactionDeleted(item.getCodeType(), language) <= 0 ){
						response.setResult(false);
						break;
					}
				}
			}
		}

		return response.build();

	}
	@Override
	@Route(global = false)
	public UpdateResponse postHandle(Vertx vertx, String clientId,
									 String sessionId, long contextId,
									 BassServiceProto.BAS0101U04SaveLayoutRequest request, SystemServiceProto.UpdateResponse response) throws Exception {
		SystemServiceProto.UpdateResponse.Builder rs = response.toBuilder();
		if(response.getResult())
		{			
			String hospitalCode = getHospitalCode(vertx, sessionId);
			String language = getLanguage(vertx, sessionId);
			List<BAS0101U04GrdDetailInfo> listSystemItem = request.getGrdDetailInfoList();
			
			if(!CollectionUtils.isEmpty(listSystemItem)){
				for(BAS0101U04GrdDetailInfo item : listSystemItem){
					if(item.getCode().equalsIgnoreCase("PID_SEQ") || item.getCode().equalsIgnoreCase("SEQ_STEP")) {
						BigDecimal seqValue = bas0102Repository.getSeqValue("OUT0101_SEQ", hospitalCode);
						BigDecimal codeName = CommonUtils.parseBigDecimal(item.getCodeName());
						if(item.getCode().equalsIgnoreCase("PID_SEQ")) {
							if(codeName.compareTo(seqValue) == -1) {
								rs.setMsg("PID_SEQ_WRONG" + "." + seqValue);
								rs.setResult(false);
								return rs.build();
							}
							if(codeName.compareTo(MaxSequence.OUT0101_MAX_SEQUENCE.getValue()) == 1) {
								rs.setResult(false);
								throw new ExecutionException(rs.build());
							}
						}
						if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
							String tChk = bas0102Repository.getTChkBAS0101U00Execute(hospitalCode, item.getCodeType(), item.getCode(), language);
							if("Y".equalsIgnoreCase(tChk)){
								rs.setResult(false);
								return rs.build();
							}

							Bas0102 bas0102 = new Bas0102();
							bas0102.setSysDate(new Date());
							bas0102.setSysId(request.getUserId());
							bas0102.setUpdDate(new Date());
							bas0102.setUpdId(request.getUserId());
							bas0102.setHospCode(hospitalCode);
							bas0102.setCodeType("STARTING_PID");
							bas0102.setCode(item.getCode());
							bas0102.setCodeName(item.getCodeName());
							bas0102.setGroupKey(item.getGroupKey());
							bas0102.setRemark(item.getRemark());
							bas0102.setSortKey(CommonUtils.parseDouble(item.getSortKey()));
							bas0102.setLanguage(language);
							
							bas0102 = bas0102Repository.save(bas0102);
							
							if(bas0102 != null && bas0102.getId() != null){
								if(item.getCode().equalsIgnoreCase("PID_SEQ")){
									if(bas0102Repository.updateSequencePidSeq(item.getCodeName(), SeqName.OUT0101_SEQ.getValue(), hospitalCode) > 0) {
										LOGGER.info("Update SWT_Sequence case PID_SEQ success");
									}
								}
								if(item.getCode().equalsIgnoreCase("SEQ_STEP")){
									if(bas0102Repository.updateSequenceSeqStep(item.getCodeName(), SeqName.OUT0101_SEQ.getValue(), hospitalCode) > 0) {
										LOGGER.info("Update SWT_Sequence case SEQ_STEP success");
									}
								}
							}
							
						} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
							if(bas0102Repository.updateBas0102U04(request.getUserId(), new Date(), item.getCodeName(), item.getCodeType(), item.getCode(), hospitalCode, language) <= 0 ){
								rs.setResult(false);
								return rs.build();
							} else {
								if(item.getCode().equalsIgnoreCase("PID_SEQ")){
									if(bas0102Repository.updateSequencePidSeq(item.getCodeName(), SeqName.OUT0101_SEQ.getValue(), hospitalCode) > 0) {
										LOGGER.info("Update SWT_Sequence case PID_SEQ success");
									}
								}
								if(item.getCode().equalsIgnoreCase("SEQ_STEP")){
									if(bas0102Repository.updateSequenceSeqStep(item.getCodeName(), SeqName.OUT0101_SEQ.getValue(), hospitalCode) > 0) {
										LOGGER.info("Update SWT_Sequence case SEQ_STEP success");
									}
								}
								
								// Publish event to MBS 
								if(item.getCode().equals("USE_MOVIE_TALK") || item.getCode().equals("USE_SURVEY")){
									NuroModelProto.MbsConfig.Builder mbsConfig = NuroModelProto.MbsConfig.newBuilder();
											mbsConfig.setLocale(!StringUtils.isEmpty(language) ? language : "");
											if (item.getCode().equals("USE_MOVIE_TALK")) {
												mbsConfig.setUseMovieTalk(item.getCodeName());
											} else if (item.getCode().equals("USE_SURVEY")) {
												mbsConfig.setUseSurvey(item.getCodeName());
											}
									NuroServiceProto.HospitalEvent.Builder message = NuroServiceProto.HospitalEvent.newBuilder()
											.setHospCode(hospitalCode)
											.setMbsConfig(mbsConfig);
									publish(vertx, message.build());						
								}
							}
							
						} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
							if(bas0102Repository.deleteBAS0101U00Execute(hospitalCode, item.getCodeType(), item.getCode(), language) <= 0 ){
								rs.setResult(false);
								return rs.build();
							}
						}					
					} else {
						if(item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
							String tChk = bas0102Repository.getTChkBAS0101U00Execute(hospitalCode, item.getCodeType(), item.getCode(), language);
							if("Y".equalsIgnoreCase(tChk)){
								rs.setResult(false);
								return rs.build();
							}

							Bas0102 bas0102 = new Bas0102();
							bas0102.setSysDate(new Date());
							bas0102.setSysId(request.getUserId());
							bas0102.setUpdDate(new Date());
							bas0102.setUpdId(request.getUserId());
							bas0102.setHospCode(hospitalCode);
							bas0102.setCodeType(item.getCodeType());
							bas0102.setCode(item.getCode());
							bas0102.setCodeName(item.getCodeName());
							bas0102.setGroupKey(item.getGroupKey());
							bas0102.setRemark(item.getRemark());
							bas0102.setSortKey(CommonUtils.parseDouble(item.getSortKey()));
							bas0102.setLanguage(language);
							bas0102Repository.save(bas0102);
						} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
							if(bas0102Repository.updateBAS0101U00Execute(hospitalCode, request.getUserId(), new Date(), item.getCodeName(),item.getGroupKey(),
									item.getRemark(), CommonUtils.parseDouble(item.getSortKey()), item.getCodeType(), item.getCode(), language) <= 0 ){
								rs.setResult(false);
								return rs.build();
							}
							
							// Publish event to MBS 
							if(item.getCode().equals("USE_MOVIE_TALK") || item.getCode().equals("USE_SURVEY")){
								NuroModelProto.MbsConfig.Builder mbsConfig = NuroModelProto.MbsConfig.newBuilder();
										mbsConfig.setLocale(!StringUtils.isEmpty(language) ? language : "");
										if (item.getCode().equals("USE_MOVIE_TALK")) {
											mbsConfig.setUseMovieTalk(item.getCodeName());
										} else if (item.getCode().equals("USE_SURVEY")) {
											mbsConfig.setUseSurvey(item.getCodeName());
										}
								NuroServiceProto.HospitalEvent.Builder message = NuroServiceProto.HospitalEvent.newBuilder()
										.setHospCode(hospitalCode)
										.setMbsConfig(mbsConfig);
								publish(vertx, message.build());						
							}
							
						} else if(item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
							if(bas0102Repository.deleteBAS0101U00Execute(hospitalCode, item.getCodeType(), item.getCode(), language) <= 0 ){
								rs.setResult(false);
								return rs.build();
							}
						}
					}
				}
			}
			rs.setResult(true);

		}
		return rs.build();
	}
}
