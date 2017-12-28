package nta.med.service.ihis.handler.nuro;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ifs.Ifs0003;
import nta.med.core.domain.out.Out1001;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.TrueFalse;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.orca.OrcaReceptionRepositoty;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.nuro.NUR2016U02TranferSgCodeInfo;
import nta.med.data.model.ihis.nuro.ORCATransferOrdersDiseaseInfo;
import nta.med.data.model.ihis.orca.ORCATransferOrdersClaimExaminationFeeInfo;
import nta.med.data.model.ihis.orca.ORCATransferOrdersClaimOrdersFeeInfo;
import nta.med.data.model.ihis.orca.ORCATransferOrdersErrMsgInfo;
import nta.med.data.model.ihis.orca.ORCATransferOrdersHeaderInfo;
import nta.med.data.model.ihis.orca.ORCATransferOrdersHealthInsuranceInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroModelProto.NUR2016U02TranferInfo;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016U02TranferRequest;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2016U02TranferResponse;
import nta.med.service.orca.proto.OrcaModelProto;

@Service                                                                                                          
@Scope("prototype")
public class NUR2016U02TranferHandler extends ScreenHandler<NuroServiceProto.NUR2016U02TranferRequest, NuroServiceProto.NUR2016U02TranferResponse>{
	
	private static final Log LOGGER = LogFactory.getLog(NUR2016U02TranferHandler.class);
	@Resource                                                                                                       
	private OutsangRepository outsangRepository;    
	
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository; 
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Ocs0103Repository ocs0103Repository;
	
	@Resource
	private OrcaReceptionRepositoty orcaReceptionRepositoty;
	
	@Resource
	Ifs0003Repository ifs0003Repository;
	
	@Resource
	Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR2016U02TranferResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2016U02TranferRequest request) throws Exception {
		NuroServiceProto.NUR2016U02TranferResponse.Builder response = NuroServiceProto.NUR2016U02TranferResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		List<NUR2016U02TranferInfo> transferInfos =  request.getListItemList();
		if(!CollectionUtils.isEmpty(transferInfos)){
			for(NUR2016U02TranferInfo transferInfo : transferInfos){
				String bunho = transferInfo.getBunho();
				Double pkout1001 = CommonUtils.parseDouble(transferInfo.getPkout1001());
				// Check status of all orders per each examination
				List<String> listStatus = ocs1003Repository.checkOrderStatus(hospCode, bunho, pkout1001);
				if(CollectionUtils.isEmpty(listStatus)){
					OrcaModelProto.ORCATransferOrdersErrMsgInfo.Builder info = OrcaModelProto.ORCATransferOrdersErrMsgInfo
							.newBuilder()
							.setHangmogCode("")
							.setHangmogName("")
							.setErrCode("2");
					
					response.addErrMsgItem(info);
					return response.build();
				}
				
				List<ORCATransferOrdersHeaderInfo> listHeader = bas0001Repository.getORCATransferOrdersHeaderInfo(hospCode, language);
				if(!CollectionUtils.isEmpty(listHeader)){
					// get deparment_code
					String deparmentCode = "";
					Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(hospCode, pkout1001);
					if(out1001 != null){
						List<Ifs0003> depts = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, AccountingConfig.IF_ORCA_GWA.getValue(), out1001.getGwa());
						if(!CollectionUtils.isEmpty(depts)){
							deparmentCode = depts.get(0).getIfCode();
						}
					}
					for(ORCATransferOrdersHeaderInfo item : listHeader){
		    			OrcaModelProto.ORCATransferOrdersHeaderInfo.Builder info = OrcaModelProto.ORCATransferOrdersHeaderInfo.newBuilder();
		    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		    			info.setDeparmentCode(deparmentCode);
						response.setHeaderItem(info);
		    		}
				}
				
				List<ORCATransferOrdersHealthInsuranceInfo> listHealthInsur = bas0001Repository.getORCATransferOrdersHealthInsuranceInfo(hospCode, bunho, pkout1001, language);
				if(!CollectionUtils.isEmpty(listHealthInsur)){
					for(ORCATransferOrdersHealthInsuranceInfo item : listHealthInsur){
						OrcaModelProto.ORCATransferOrdersHealthInsuranceInfo.Builder info = OrcaModelProto.ORCATransferOrdersHealthInsuranceInfo.newBuilder();
		    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addHealthInsItem(info);
		    		}
				} else {
					OrcaModelProto.ORCATransferOrdersHealthInsuranceInfo.Builder info = OrcaModelProto.ORCATransferOrdersHealthInsuranceInfo
							.newBuilder()
							.setPriorityNumber("")
							.setProviderName("")
							.setPublicStartDate("")
							.setPublicEndDate("")
							.setEncounterDate("")
							.setInsuranceCode("XX")
							.setInsuranceNumber("9999")
							.setInsuranceStartDate(new SimpleDateFormat("yyyy/MM/dd").format(new Date()))
							.setInsuranceEndDate("9999/12/31");
					
					response.addHealthInsItem(info);
				}
				
				List<ORCATransferOrdersDiseaseInfo> listDisease = outsangRepository.getORCATransferOrdersDiseaseInfo(hospCode, bunho);
				if(!CollectionUtils.isEmpty(listDisease)){
					for(ORCATransferOrdersDiseaseInfo item : listDisease){
						OrcaModelProto.ORCATransferOrdersDiseaseInfo.Builder info = OrcaModelProto.ORCATransferOrdersDiseaseInfo.newBuilder();
		    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addDiseaseItem(info);
		    		}
				}
				
				// Check class_code is exist
				List<ORCATransferOrdersErrMsgInfo> errList = new ArrayList<ORCATransferOrdersErrMsgInfo>();
				List<NUR2016U02TranferSgCodeInfo> listSgCode =  ocs1003Repository.getNUR2016U02TranferInfo(hospCode, bunho);
//				get NUR2016U02TranferInfo  response 
				NuroModelProto.NUR2016U02TranferInfo.Builder transferRes = NuroModelProto.NUR2016U02TranferInfo.newBuilder();
				transferRes.setBunho(bunho);
				if(!CollectionUtils.isEmpty(listSgCode)){
					for(NUR2016U02TranferSgCodeInfo info : listSgCode){
						List<Ifs0003> listIfs0003 = ifs0003Repository.findByHospCodeAndMapGubunAndOcsCode(hospCode, "IF_ORCA_HANGMOG", info.getHangmogCode());
						if(CollectionUtils.isEmpty(listIfs0003)){
							errList.add(new ORCATransferOrdersErrMsgInfo(info.getHangmogCode(), info.getHangmogName(), "0"));
						}else{
							for(Ifs0003 ifs : listIfs0003){
								if(StringUtils.isEmpty(ifs.getIfCode())){
									errList.add(new ORCATransferOrdersErrMsgInfo(info.getHangmogCode(), info.getHangmogName(), "1"));
								}
							}
						}
						NuroModelProto.NUR2016U02ListPkocsInfo.Builder pkocs = NuroModelProto.NUR2016U02ListPkocsInfo.newBuilder();
						if(info.getPkocs1003() != null){
							pkocs.setPkocs(String.format("%.0f", info.getPkocs1003()));
						}
						transferRes.addListItem(pkocs);
					}
				}
				response.addListinfoItem(transferRes);
				List<ORCATransferOrdersClaimExaminationFeeInfo> listClaimExam = orcaReceptionRepositoty.getORCATransferOrdersClaimExaminationFeeInfo(hospCode, pkout1001);
				if(!CollectionUtils.isEmpty(listClaimExam)){
					for(ORCATransferOrdersClaimExaminationFeeInfo item : listClaimExam){
						OrcaModelProto.ORCATransferOrdersClaimExaminationFeeInfo.Builder info = OrcaModelProto.ORCATransferOrdersClaimExaminationFeeInfo.newBuilder();
		    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		    			if(!StringUtils.isEmpty(item.getIoFlag())){
		    				if(TrueFalse.FALSE.getValue().equalsIgnoreCase(item.getIoFlag())){
		    					info.setIoFlag(false);
		    				}else if(TrueFalse.TRUE.getValue().equalsIgnoreCase(item.getIoFlag())){
		    					info.equals(true);
		    				}
		    			}
						response.addClaimExamItem(info);
		    		}
				}
				
				List<String> listHangmocCode = new ArrayList<String>();
				for (NUR2016U02TranferSgCodeInfo hm : listSgCode) {
					listHangmocCode.add(hm.getHangmogCode());
				}
				
				List<ORCATransferOrdersClaimOrdersFeeInfo> listClaimIOrder = ocs1003Repository.getORCATransferOrdersClaimOrdersFeeInfo(hospCode, language, bunho, pkout1001, listHangmocCode);
				if(!CollectionUtils.isEmpty(listClaimIOrder)){
					for(ORCATransferOrdersClaimOrdersFeeInfo item : listClaimIOrder){
						OrcaModelProto.ORCATransferOrdersClaimOrdersFeeInfo.Builder info = OrcaModelProto.ORCATransferOrdersClaimOrdersFeeInfo.newBuilder();
		    			BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
						response.addClaimOrdersItem(info);
		    		}
				}
				for(ORCATransferOrdersErrMsgInfo item : errList){
					OrcaModelProto.ORCATransferOrdersErrMsgInfo.Builder info = OrcaModelProto.ORCATransferOrdersErrMsgInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addErrMsgItem(info);
				}
			}
		}
		return response.build();
	} 

}
