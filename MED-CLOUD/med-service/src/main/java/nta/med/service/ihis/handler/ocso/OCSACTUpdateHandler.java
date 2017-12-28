package nta.med.service.ihis.handler.ocso;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.config.Configuration;
import nta.med.core.domain.adm.Adm3200;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.inv.*;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.dao.medi.inv.*;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocso.PrOcsIudBomOrderActInfo;
import nta.med.data.model.ihis.ocso.PrOcsLoadSubulSuryangInfo;
import nta.med.service.ihis.proto.OcsoModelProto.OCSACTDeleteJaeryoInfo;
import nta.med.service.ihis.proto.OcsoModelProto.OCSACTUpdJaeryoProcessInfo;
import nta.med.service.ihis.proto.OcsoModelProto.OCSACTUpdJaeryoProcessWithUpdGubunInfo;
import nta.med.service.ihis.proto.OcsoModelProto.OCSACTUpdateGrdOrderInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class OCSACTUpdateHandler extends ScreenHandler<OcsoServiceProto.OCSACTUpdateRequest, SystemServiceProto.UpdateResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTUpdateHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository; 
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;
	@Resource
	private Cpl2010Repository cpl2010Repository;
	@Resource
	private Inv1001Repository inv1001Repository;
	@Resource
	private Ocs0103Repository ocs0103Repository;
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Ocs0132Repository ocs0132Repository;
	@Resource
	private Inv0110Repository inv0110Repository;
	@Resource
	private Bas0102Repository bas0102Repository;
	@Resource
	private Inv0001Repository inv0001Repository;
	@Resource
	private Inv2003Repository inv2003Repository;
	@Resource
	private Inv2004Repository inv2004Repository;
	@Resource
	private Adm3200Repository adm3200Repository;
	@Resource
	private Inv4001Repository inv4001Repository;
	@Resource
	private Inv4002Repository inv4002Repository;
    @Resource
    private Inv0102Repository inv0102Repository;
    @Resource
    private Bas0001Repository bas0001Repository;
	@Resource
	private Configuration configuration;
    
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTUpdateRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
  	   	Integer result  = null;
  	    String ioErrMsg = null;
  	    Double newOcsKey = CommonUtils.parseDouble(request.getNewOcsKey());
  	    String hospCode = getHospitalCode(vertx, sessionId);
  	    String language = getLanguage(vertx, sessionId);
  	    String userId = getUserId(vertx, sessionId);
		// check hospital using inventory or not
		List<ComboListItemInfo> combos = bas0102Repository.getComboListItemInfoByCodeType(hospCode, getLanguage(vertx, sessionId), "INV_USAGE");
		boolean isInventory = combos.size() > 0 && "Y".equals(combos.get(0).getCode());
//		get local time zone
		Integer localTimeZone = getTimeZone(vertx, sessionId);
		if(localTimeZone == null){
			List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(hospCode);
			if (!CollectionUtils.isEmpty(bas0001List)) {
				Bas0001 bas0001 = bas0001List.get(0);
				localTimeZone = bas0001.getTimeZone() != null ? bas0001.getTimeZone() : configuration.getDefaultTimeZone();
			} else{
				localTimeZone = configuration.getDefaultTimeZone();
			}
		}
		int defaultTimeZone = configuration.getDefaultTimeZone() != null ? configuration.getDefaultTimeZone() : 9;		
		Date sysDate = CommonUtils.getLocalDateTime(defaultTimeZone, localTimeZone);
		SimpleDateFormat localDateFormat = new SimpleDateFormat("HHmm");
		String churiTime = localDateFormat.format(sysDate);
		//Update 1
		for(OCSACTUpdateGrdOrderInfo info : request.getUpdateGrdOrderItemList()){//start for OCSACTUpdateGrdOrderInfo
			  String jaeryoCode = info.getHangmogCode();
	          String hangmogInventoryYn = inv0110Repository.checkInvenByHangmogCode(hospCode, jaeryoCode);
	          //Double ipgoQty = CommonUtils.parseDouble(info.getSuryang()) * CommonUtils.parseDouble("1") * CommonUtils.parseDouble(info.getNalsu());
	          Double ipgoQty = commonRepository.callFnDrgWonyoiTotSurang(CommonUtils.parseDouble(info.getNalsu()), CommonUtils.parseDouble(info.getSuryang()), CommonUtils.parseDouble("1"), "*");
	          Double fkocs1003 = CommonUtils.parseDouble(info.getPkocs1003());
			if(request.getRbtNonAct()){ // region nbxNonAct is checked
				if("Y".equalsIgnoreCase(info.getGrdOrderActYn())){
				Double pkOcs = CommonUtils.parseDouble(info.getPkocs());
				Double suryang = CommonUtils.parseDouble(info.getSuryang());
				Double nalsu = CommonUtils.parseDouble(info.getNalsu());
				Date jubsuDate = DateUtil.toDate(info.getJubsuDate(),DateUtil.PATTERN_YYMMDD);
				Date actingDate =  DateUtil.toDate(info.getGrdOrderActingDate(), DateUtil.PATTERN_YYMMDD);
				String tempOrder = null;
				List<String> listCode = ocs0132Repository.getGroupKeyFromVwOcsDummyOrderMaster(info.getHangmogCode());
				if(!CollectionUtils.isEmpty(listCode)){
					tempOrder = listCode.get(0);
				}
				
				if (!StringUtils.isEmpty(tempOrder)) {
					if("O".equalsIgnoreCase(info.getGrdOrderInOutGubun())){
						result = ocs1003Repository.updateOCSACTOcs1003ChangeNurSeRemarkAndUpdId(hospCode, info.getRemark(), pkOcs );
					}
					if("I".equalsIgnoreCase(info.getGrdOrderInOutGubun())){
						result = ocs2003Repository.updateOCSACTOcs2003ChangeNurSeRemarkAndUpdId(hospCode, info.getRemark(), pkOcs );
					}
				}
				
				if("3".equalsIgnoreCase(info.getInputControl())){
					if("O".equalsIgnoreCase(info.getGrdOrderInOutGubun())){
						result = ocs1003Repository.updateOCSATOcs1003ChangeSuRyangNalsu(hospCode, suryang, nalsu, pkOcs);
					}else{
						result = ocs2003Repository.updateOCSATOcs2003ChangeSuRyangNalsu(hospCode, suryang, nalsu, pkOcs);
					}
				}
				// [PR_OCS_UPDATE_ACTING 処理]
				ocs1003Repository.callPrOcsUpdateActing(hospCode,request.getInOutGubun(), pkOcs, info.getJundalPart(),
						jubsuDate,info.getJubsuTime(),actingDate,info.getGrdOrderActingTime(), info.getActDoctor());
				// [PR_SCH_UPDATE_ACTING 処理]
				cpl2010Repository.callCPL2010U00PrSchUpdateActing(hospCode,info.getGrdOrderInOutGubun(), pkOcs, actingDate);
				// [PR_OCS_REAL_ORDER_FROM_DUMMY 処理]
				if(!StringUtils.isEmpty(tempOrder)){
					newOcsKey = ocs1003Repository.callPrOcsoRealOrderFromDummy(hospCode, info.getGrdOrderInOutGubun(), pkOcs,
							info.getActDoctor(), info.getInputGubun(), info.getHangmogCode());
				}else{
					newOcsKey = CommonUtils.parseDouble(info.getPkocs());
				}
				if(isInventory && YesNo.YES.getValue().equals(hangmogInventoryYn)){
					inventoryHistoryCaseTick(hospCode, userId, jaeryoCode, ipgoQty, fkocs1003, language, churiTime);
	          	}
				}
			} //end if region nbxNonAct is checked
			
			
			if(request.getRbtAct()){ // region rbt act is checked 
				if("N".equalsIgnoreCase(info.getGrdOrderActYn())){
					Double pkOcs = null;
					if(StringUtils.isEmpty(request.getSortFkocskey())){
						pkOcs = CommonUtils.parseDouble(info.getPkocs());
					}else{
						pkOcs = CommonUtils.parseDouble(request.getSortFkocskey());
					}
					// PR_OCS_UPDATE_ACTING
					ocs1003Repository.callPrOcsUpdateActing(hospCode, info.getGrdOrderInOutGubun(), pkOcs, null, null, null,null, null, null);
					// PR_SCH_UPDATE_ACTING
					Date actingDate = null;
					cpl2010Repository.callCPL2010U00PrSchUpdateActing(hospCode, info.getGrdOrderInOutGubun(), pkOcs, actingDate);
					
					for(OCSACTUpdJaeryoProcessWithUpdGubunInfo infoJaeryo : request.getJaeryoWithUpdItemList()){ //start for OCSACTUpdJaeryoProcessWithUpdGubunInfo
						Double pkinv1001 = CommonUtils.parseDouble(infoJaeryo.getPkinv1001());
						result = inv1001Repository.deleteINV1001ByPkinv1001(hospCode, pkinv1001);
						Double bomSourceKey = CommonUtils.parseDouble(infoJaeryo.getFkocsXrt());
						Double pkOcs2003 = CommonUtils.parseDouble(infoJaeryo.getFkocsInv());
						String jaeryoCodeUpd = infoJaeryo.getHangmogCode();
				        String hangmogInventoryYnUpd = inv0110Repository.checkInvenByHangmogCode(hospCode, jaeryoCodeUpd);
				        //Double ipgoQtyUpd = CommonUtils.parseDouble(infoJaeryo.getSuryang()) * CommonUtils.parseDouble("1") * CommonUtils.parseDouble(infoJaeryo.getNalsu());
				        Double ipgoQtyUpd = commonRepository.callFnDrgWonyoiTotSurang(CommonUtils.parseDouble(infoJaeryo.getNalsu()), CommonUtils.parseDouble(infoJaeryo.getSuryang()), CommonUtils.parseDouble("1"), "*");
				        Double fkocs1003Upd = CommonUtils.parseDouble(infoJaeryo.getFkocsInv());
						if(bomSourceKey != null && pkOcs2003 != null){
							Double suryang =  CommonUtils.parseDouble(infoJaeryo.getSuryang());
							Double nalsu = CommonUtils.parseDouble(info.getNalsu());
							PrOcsIudBomOrderActInfo prResult =  null;
							if("I".equalsIgnoreCase(request.getInOutGubun())){
								Date orderDate = DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD);
								 prResult = ocs2003Repository.callPrOcsIudBomInpOrderAct(hospCode,language,
										"D", request.getUserId(),request.getJundalPart(), orderDate, bomSourceKey,
										pkOcs2003, infoJaeryo.getHangmogCode(), suryang, null, null, null, nalsu, infoJaeryo.getOrdDanui());
							}else{
								prResult = ocs1003Repository.callPrOcsIudBomOutOrderAct(hospCode,language,
										"D",request.getUserId(),request.getJundalPart(), bomSourceKey,
										pkOcs2003, infoJaeryo.getHangmogCode(), suryang, null, null, null, nalsu, infoJaeryo.getOrdDanui());
							}
							if(prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())){
								ioErrMsg = prResult.getIoErrMsg();
								if(!StringUtils.isEmpty(ioErrMsg)){
									response.setMsg(ioErrMsg);
								}
								response.setResult(false);
								throw new ExecutionException(response.build());
							}
						}
						if(isInventory && YesNo.YES.getValue().equals(hangmogInventoryYnUpd)){
		                	inventoryHistoryCaseUnTick(hospCode, language, userId, ipgoQtyUpd, fkocs1003Upd, jaeryoCodeUpd, churiTime);
			          	}
					}//end for OCSACTUpdJaeryoProcessWithUpdGubunInfo
					if(isInventory && YesNo.YES.getValue().equals(hangmogInventoryYn)){
	                	inventoryHistoryCaseUnTick(hospCode, language, userId, ipgoQty, fkocs1003, jaeryoCode, churiTime);
		          	}
				}
			} //end if region rbt act is checked 
		} // end for OCSACTUpdateGrdOrderInfo
		
		//Update 2
		if((request.getRbtNonAct() && !"N".equalsIgnoreCase(request.getActYn())) || request.getRbtAct()){
			for(OCSACTUpdJaeryoProcessInfo info : request.getJaeryoItemList()){ //start for OCSACTUpdJaeryoProcessInfo
//				if(!"Y".equalsIgnoreCase(request.getActYn())){
//					break;
//				}
				if(StringUtils.isEmpty(info.getSuryang())){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
				 if(DataRowState.ADDED.getValue().equals(info.getRowState())){
					 String jaeryoCode = info.getHangmogCode();
			         String hangmogInventoryYn = inv0110Repository.checkInvenByHangmogCode(hospCode, jaeryoCode);
			         Double ipgoQty = CommonUtils.parseDouble(info.getSuryang()) * CommonUtils.parseDouble("1") * CommonUtils.parseDouble(info.getNalsu());
			         //Double fkocs1003 = CommonUtils.parseDouble(info.getFkocsInv());
			         Double fkocs1003 = CommonUtils.parseDouble(request.getPkocs());
					 if("I".equalsIgnoreCase(request.getInOutGubun())){
							Double suryang =  CommonUtils.parseDouble(info.getSuryang());
							Double pkOcs2003 =  new Double(0);
							Double nalsu = StringUtils.isEmpty(info.getNalsu()) ? new Double(1) : CommonUtils.parseDouble(info.getNalsu());
							Date orderDate = DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD);
							Date actingDate = DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD);
							PrOcsIudBomOrderActInfo prResult = ocs2003Repository.callPrOcsIudBomInpOrderAct(hospCode,language,
									"I", request.getUserId(), request.getJundalPart(), orderDate, newOcsKey,
									pkOcs2003, info.getHangmogCode(), suryang, actingDate, request.getActingTime(), null, nalsu, info.getOrdDanui());
							if(prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())){
								ioErrMsg = prResult.getIoErrMsg();
								if(!StringUtils.isEmpty(ioErrMsg)){
									response.setMsg(ioErrMsg);
								}
								response.setResult(false);
								throw new ExecutionException(response.build());
							}
							//getpkOcs2003
							Double pkocsInv = null;
							if(prResult != null){
								pkocsInv = prResult.getIoPkocs2003();
							}
							//PR_OCS_LOAD_SUBUL_SURYANG
							Integer orderSuyang = CommonUtils.parseInteger(info.getSuryang());
							PrOcsLoadSubulSuryangInfo prOcsSuryang = ocs0103Repository.callPrOcsLoadSubulSuryang(hospCode, request.getInOutGubun(), info.getHangmogCode(),
									info.getOrdDanui(), new Integer(1), "*", orderSuyang, new Integer(1), new Date());
							if(prOcsSuryang != null && !"0".equalsIgnoreCase(prOcsSuryang.getoFlag())){
								response.setResult(false);
								throw new ExecutionException(response.build());
							}
							 // inv1001 save
							String subulDanui = null;
							Double subulSuryang = null;
							if(prOcsSuryang != null){
								subulDanui =  prOcsSuryang.getSubulDanui() == null ? info.getOrdDanui() : prOcsSuryang.getSubulDanui();
								subulSuryang = prOcsSuryang.getSubulSuryang() == null ? new Double(1) : prOcsSuryang.getSubulSuryang().doubleValue();
							}
							Double pkinv1001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV1001_SEQ"));
							if(pkinv1001 != null){
								insertINV1001(info,request.getUserId(), pkinv1001,request.getBunho(), orderDate, request.getInOutGubun(), request.getJundalPart(),
										subulSuryang, subulDanui, pkocsInv, newOcsKey, request.getInOutGubun(), language);
								result = 1;
							}
					 }else{
						    Date orderDate = DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD);
						    Double suryang =  CommonUtils.parseDouble(info.getSuryang());
							Double pkOcs2003 =  new Double(0);
							Double nalsu = StringUtils.isEmpty(info.getNalsu()) ? new Double(1) : CommonUtils.parseDouble(info.getNalsu());
							Date actingDate = DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD);
							PrOcsIudBomOrderActInfo prResult = ocs1003Repository.callPrOcsIudBomOutOrderAct(hospCode,language,
									"I", request.getUserId(),request.getJundalPart(), newOcsKey,
									pkOcs2003,info.getHangmogCode(),suryang,actingDate,request.getActingTime(), null, nalsu,info.getOrdDanui());
							if(prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())){
								ioErrMsg = prResult.getIoErrMsg();
								if(!StringUtils.isEmpty(ioErrMsg)){
									response.setMsg(ioErrMsg);
								}
								response.setResult(false);
								throw new ExecutionException(response.build());
							}
							//insert ocskey
							Double pkocsInv = null;
							if(prResult != null){
								pkocsInv = prResult.getIoPkocs2003();
							}
							//PR_OCS_LOAD_SUBUL_SURYANG
							Integer orderSuyang = CommonUtils.parseInteger(info.getSuryang());
							PrOcsLoadSubulSuryangInfo prOcsSuryang = ocs0103Repository.callPrOcsLoadSubulSuryang(hospCode, request.getInOutGubun(), info.getHangmogCode(),
									info.getOrdDanui(), new Integer(1), "*", orderSuyang, new Integer(1), new Date());
							if(prOcsSuryang != null && !"0".equalsIgnoreCase(prOcsSuryang.getoFlag())){
								response.setResult(false);
								throw new ExecutionException(response.build());
							}
							 // inv1001 save
							String subulDanui = null;
							Double subulSuryang = null;
							if(prOcsSuryang != null){
								subulDanui =  prOcsSuryang.getSubulDanui() == null ? info.getOrdDanui() : prOcsSuryang.getSubulDanui();
								subulSuryang = prOcsSuryang.getSubulSuryang() == null ? new Double(1) : prOcsSuryang.getSubulSuryang().doubleValue();
							}
							Double pkinv1001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV1001_SEQ"));
							if(pkinv1001 != null){
								insertINV1001(info,request.getUserId(), pkinv1001,request.getBunho(), orderDate, request.getInOutGubun(), request.getJundalPart(),
										subulSuryang, subulDanui, pkocsInv, newOcsKey, request.getInOutGubun(), hospCode);
								result = 1;
							}
					 } //end if check equal I
					// logic inventoty
					 if(isInventory && YesNo.YES.getValue().equals(hangmogInventoryYn)){
							inventoryHistoryCaseTick(hospCode, userId, jaeryoCode, ipgoQty, fkocs1003, language, churiTime);
			        }
				 }if(DataRowState.MODIFIED.getValue().equals(info.getRowState())){
					    Integer orderSuyang = CommonUtils.parseInteger(info.getSuryang());
						String gubun = request.getInOutGubun();
						PrOcsLoadSubulSuryangInfo prOcsSuryang = ocs0103Repository.callPrOcsLoadSubulSuryang(hospCode, gubun, info.getHangmogCode(),
								info.getOrdDanui(), new Integer(1), "*", orderSuyang, new Integer(1), new Date());
						if(prOcsSuryang != null && !"0".equalsIgnoreCase(prOcsSuryang.getoFlag())){
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
						String subulDanui = null;
						Double subulSuryang = null;
						if(prOcsSuryang != null){
							subulDanui =  prOcsSuryang.getSubulDanui() == null ? info.getOrdDanui() : prOcsSuryang.getSubulDanui();
							subulSuryang = prOcsSuryang.getSubulSuryang() == null ? new Double(1) : prOcsSuryang.getSubulSuryang().doubleValue();
						}
						// update inv1001
						Double pkinv1001 = CommonUtils.parseDouble(info.getPkinv1001());
						Double nalsu = StringUtils.isEmpty(info.getNalsu()) ? new Double(1) : CommonUtils.parseDouble(info.getNalsu());
						result = inv1001Repository.updateInv1001(hospCode, request.getUserId(), info.getHangmogCode(), subulSuryang, subulDanui,nalsu, pkinv1001);
						
						 Double bomSourceKey = CommonUtils.parseDouble(info.getFkocsXrt());
						 Double pkOcs2003 = CommonUtils.parseDouble(info.getFkocsInv());
						 Double suryang =  CommonUtils.parseDouble(info.getSuryang());
						 Date actingDate = DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD);
						 String actingTime = request.getActingTime();
						 PrOcsIudBomOrderActInfo prResult =  null;
							if("I".equalsIgnoreCase(request.getInOutGubun())){
								Date orderDate = DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD);
								 prResult = ocs2003Repository.callPrOcsIudBomInpOrderAct(hospCode,language,
										"U", request.getUserId(),request.getJundalPart(), orderDate, bomSourceKey,
										pkOcs2003, info.getHangmogCode(), suryang, actingDate, actingTime, null, nalsu, info.getOrdDanui());
								
							}else{
								prResult = ocs1003Repository.callPrOcsIudBomOutOrderAct(hospCode,language,
										"U",request.getUserId(),request.getJundalPart(), bomSourceKey,
										pkOcs2003, info.getHangmogCode(), suryang, actingDate, actingTime, null, nalsu, info.getOrdDanui());
							}
							if(prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())){
								ioErrMsg = prResult.getIoErrMsg();
								if(!StringUtils.isEmpty(ioErrMsg)){
									response.setMsg(ioErrMsg);
								}
								response.setResult(false);
								throw new ExecutionException(response.build());
							}
				 }
			} //end for OCSACTUpdJaeryoProcessInfo
			 for(OCSACTDeleteJaeryoInfo  info : request.getDeleteJaeryoItemList()){ //start for OCSACTDeleteJaeryoInfo
				 Double pkinv1001 = CommonUtils.parseDouble(info.getPkinv1001());
				 result = inv1001Repository.deleteINV1001ByPkinv1001(hospCode, pkinv1001);
				 
				 Double bomSourceKey = CommonUtils.parseDouble(info.getFkocsXrt());
				 Double pkOcs2003 = CommonUtils.parseDouble(info.getFkocsInv());
				 Double suryang =  CommonUtils.parseDouble(info.getSuryang());
				 Double nalsu = CommonUtils.parseDouble(info.getNalsu());
				 String jaeryoCode = info.getHangmogCode();
				 String hangmogInventoryYn = inv0110Repository.checkInvenByHangmogCode(hospCode, jaeryoCode);
		         Double ipgoQty = CommonUtils.parseDouble(info.getSuryang()) * CommonUtils.parseDouble("1") * CommonUtils.parseDouble(info.getNalsu());
		         //Double fkocs1003 = CommonUtils.parseDouble(info.getFkocsInv());
		         Double fkocs1003 = CommonUtils.parseDouble(request.getPkocs());
				 PrOcsIudBomOrderActInfo prResult =  null;
					if("I".equalsIgnoreCase(request.getInOutGubun())){
						Date orderDate = DateUtil.toDate(request.getOrderDate(),DateUtil.PATTERN_YYMMDD);
						 prResult = ocs2003Repository.callPrOcsIudBomInpOrderAct(hospCode, language,
								"D", request.getUserId(),request.getJundalPart(), orderDate, bomSourceKey,
								pkOcs2003,info.getHangmogCode(),suryang,null, null, null, nalsu,info.getOrdDanui());
						
					}else{
						prResult = ocs1003Repository.callPrOcsIudBomOutOrderAct(hospCode, language,
								"D", request.getUserId(), request.getJundalPart(), bomSourceKey,
								pkOcs2003, info.getHangmogCode(),suryang, null, null, null, nalsu, info.getOrdDanui());
					}
					if(prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())){
						ioErrMsg = prResult.getIoErrMsg();
						if(!StringUtils.isEmpty(ioErrMsg)){
							response.setMsg(ioErrMsg);
						}
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					if(isInventory && YesNo.YES.getValue().equals(hangmogInventoryYn)){
	                	inventoryHistoryCaseUnTick(hospCode, language, userId, ipgoQty, fkocs1003, jaeryoCode, churiTime);
		          	}
			} //end for OCSACTDeleteJaeryoInfo
		}
		
		// Update 3
		if(request.getRbtAct() && "N".equalsIgnoreCase(request.getActYn())){
			if(!StringUtils.isEmpty(request.getSortFkocskey())){
				String ioGubun = request.getInOutGubun();
				Double pkocs = CommonUtils.parseDouble(request.getSortFkocskey());
				if("O".equalsIgnoreCase(ioGubun)){
					result = ocs1003Repository.updateOCSACTOcs1003ChangeNurSeRemarkAndUpdId(hospCode, null, pkocs);
				}
				if("I".equalsIgnoreCase(ioGubun)){
					result = ocs2003Repository.updateOCSACTOcs2003ChangeNurSeRemarkAndFkOcs1003AndUpdId(hospCode, null,null, pkocs);
				}
				if(result > 0){
					if("O".equalsIgnoreCase(ioGubun)){
						result = ocs1003Repository.updateOCSACTOcs1003ChangeJubsuDateAndActingDate(hospCode, pkocs);
					}
					if("I".equalsIgnoreCase(ioGubun)){
						result = ocs2003Repository.updateOCSACTOcs2003ChangeJubsuDateAndActingDate(hospCode, pkocs);
					}
				}
				if(result > 0){
					if("O".equalsIgnoreCase(ioGubun)){
						result = ocs1003Repository.deleteOcsoOCS1003P01DeleteFromOCS1003(pkocs, hospCode);
					}
					if("I".equalsIgnoreCase(ioGubun)){
						result = ocs2003Repository.deleteOCS0103U13SaveLayout(hospCode, pkocs);
					}
				}
			}
		}
		response.setResult(result != null && result > 0);
		return response.build();
	}
	
	private void insertINV1001(OCSACTUpdJaeryoProcessInfo  info, String userId, Double pkinv1001, String bunho,
			Date orderDate, String inOutGubun, String jundalPart, Double subulSuryang, String subulDanui, Double pkocsInv, Double newOcsKey, String ioGubun, String hospCode){
		Inv1001 inv1001 = new Inv1001();
		inv1001.setSysDate(new Date());
		inv1001.setSysId(userId);
		inv1001.setUpdDate(new Date());
		inv1001.setPkinv1001(pkinv1001);
		inv1001.setBunho(bunho);
		inv1001.setOrderDate(orderDate);
		inv1001.setInOutGubun(inOutGubun);
		inv1001.setInputPart(jundalPart);
		inv1001.setHangmogCode(info.getHangmogCode());
		inv1001.setJaeryoCode(info.getHangmogCode());
		inv1001.setSubulBuseo(jundalPart);
		inv1001.setSuryang(subulSuryang);
		inv1001.setDvTime("*");
		inv1001.setDv(new Double(1));
		inv1001.setNalsu(StringUtils.isEmpty(info.getNalsu()) ? new Double(1) : CommonUtils.parseDouble(info.getNalsu()));
		inv1001.setOrdDanui(subulDanui);
		inv1001.setActingDate(new Date());
		inv1001.setActBuseo(jundalPart);
		if("I".equalsIgnoreCase(ioGubun)){
			inv1001.setFkocs2003(pkocsInv);
		}else{
			inv1001.setFkocs1003(pkocsInv);
		}
		inv1001.setBomSourceKey(newOcsKey);
		inv1001.setHospCode(hospCode);
		inv1001Repository.save(inv1001);
	}
	
	private void inventoryHistoryCaseTick(String hospCode, String userId,
			String jaeryoCode, Double chulgoQty, Double fkocs1003, String language, String churiTime){
		Double pkinv2003 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2003_SEQ"));
        Double pkinv2004 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2004_SEQ"));
        
        String churiBuseo = "";
		List<Adm3200> adm3200s = adm3200Repository.getAdm3200ByUserId(hospCode, userId);
		if(!CollectionUtils.isEmpty(adm3200s)){
			churiBuseo = adm3200s.get(0).getDeptCode();
		}
		Double churiSeq = CommonUtils.parseDouble(commonRepository.getNextVal("CHURI_SEQ"));
		 
		inv0001Repository.updateInv0001(userId, new BigDecimal("0"), hospCode, fkocs1003);
		String remark = ocs1003Repository.getRemarkOcs1003(hospCode, fkocs1003, null, language);
		
		List<String> listCodeName = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INV_EXPORT", "INV_PREFIX");
		String exportCode = CollectionUtils.isEmpty(listCodeName) ? String.valueOf(churiSeq).split("\\.")[0] : listCodeName.get(0) + String.valueOf(churiSeq).split("\\.")[0];
		
		Inv2003 inv2003 = new Inv2003();
		inv2003.setSysDate(new Date());
		inv2003.setSysId(userId);
		inv2003.setUpdDate(new Date());
		inv2003.setUpdId(userId);
		inv2003.setHospCode(hospCode);
		inv2003.setChuriDate(new Date());
		inv2003.setChuriBuseo(churiBuseo);
		inv2003.setChulgoType("ORD");
		inv2003.setChuriSeq(churiSeq);
		inv2003.setPkinv2003(pkinv2003);
		inv2003.setIpchulType("O");
		inv2003.setRemark(remark);
		inv2003.setExportCode(exportCode);
		inv2003.setChuriTime(churiTime);
		
		inv2003Repository.save(inv2003);
		
		Inv2004 inv2004 = new Inv2004();
		inv2004.setSysDate(new Date());
		inv2004.setSysId(userId);
		inv2004.setUpdDate(new Date());
		inv2004.setHospCode(hospCode);
		inv2004.setFkinv2003(pkinv2003);
		inv2004.setJaeryoCode(jaeryoCode);
		inv2004.setChulgoQty(chulgoQty);
		inv2004.setPkinv2004(pkinv2004);
		inv2004Repository.save(inv2004);
	}
    
    private void inventoryHistoryCaseUnTick(String hospCode, String language, String userId, 
			Double ipgoQty, Double fkocs1003, String jaeryoCode, String churiTime){
		
		Double pkinv4001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4001_SEQ"));
        Double pkinv4002 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4002_SEQ"));
        
        String churiBuseo = "";
		List<Adm3200> adm3200s = adm3200Repository.getAdm3200ByUserId(hospCode, userId);
		if(!CollectionUtils.isEmpty(adm3200s)){
			churiBuseo = adm3200s.get(0).getDeptCode();
		}
        
        Double churiSeq = CommonUtils.parseDouble(commonRepository.getNextVal("CHURI_SEQ"));
		
		inv0001Repository.updateInv0001(userId, new BigDecimal("1"), hospCode, fkocs1003);
		List<String> listCodeName = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INV_EXPORT", "INV_PREFIX");
		String importCode = CollectionUtils.isEmpty(listCodeName) ? String.format("%.0f", churiSeq) : listCodeName.get(0) + String.format("%.0f", churiSeq);
		String remark = ocs1003Repository.getRemarkOcs1003(hospCode, fkocs1003, null, language);
		
		Inv4001 inv4001 = new Inv4001();
		inv4001.setSysDate(new Date());
		inv4001.setSysId(userId);
		inv4001.setUpdDate(new Date());
		inv4001.setUpdId(userId);
		inv4001.setHospCode(hospCode);
		inv4001.setChuriDate( new Date());
		inv4001.setChuriBuseo(churiBuseo);
		inv4001.setIpgoType("RET");
		inv4001.setChuriSeq(churiSeq);
		inv4001.setIpchulType("I");
		inv4001.setPkinv4001(pkinv4001);
		inv4001.setImportCode(importCode);
		inv4001.setChuriTime(churiTime);
		inv4001.setRemark(remark);
		inv4001Repository.save(inv4001);
		
		Inv4002 inv4002 = new Inv4002();
		inv4002.setSysDate(new Date());
		inv4002.setSysId(userId);
		inv4002.setUpdDate(new Date());
		inv4002.setUpdId(userId);
		inv4002.setHospCode(hospCode);
		inv4002.setFkinv4001(pkinv4001);
		inv4002.setJaeryoCode(jaeryoCode);
		inv4002.setIpgoQty(ipgoQty);
		inv4002.setPkinv4002(pkinv4002);
		inv4002.setLot("10");
		inv4002.setExpiredDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
		inv4002Repository.save(inv4002);
	}
}