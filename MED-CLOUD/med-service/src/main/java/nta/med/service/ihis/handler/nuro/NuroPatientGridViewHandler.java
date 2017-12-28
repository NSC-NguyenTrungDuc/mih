package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.Out1002Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LayGongbiCodeInfo;
import nta.med.data.model.ihis.nuro.NuroPatientCommentInfo;
import nta.med.data.model.ihis.nuro.NuroPatientDetailInfo;
import nta.med.data.model.ihis.nuro.NuroPatientInsuranceInfo;
import nta.med.data.model.ihis.nuro.NuroPatientReceptionHistoryInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroPatientGridViewHandler extends ScreenHandler<NuroServiceProto.NuroPatientGridViewRequest, NuroServiceProto.NuroPatientGridViewResponse>{
	private static final Log LOG = LogFactory.getLog(NuroPatientGridViewHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Out1002Repository out1002Repository;

	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroPatientGridViewResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroPatientGridViewRequest request) throws Exception {
		 NuroServiceProto.NuroPatientGridViewResponse.Builder response = NuroServiceProto.NuroPatientGridViewResponse.newBuilder();
		 String hospCode = getHospitalCode(vertx, sessionId);
		 String language = getLanguage(vertx, sessionId);
		 if(request.getChangeComingDate()){
     		List<NuroPatientReceptionHistoryInfo> listNuroPatientReceptionHistoryInfo = out1001Repository.getNuroPatientReceptionHistoryInfo2(language, hospCode,request.getPatientCode());
         	if(listNuroPatientReceptionHistoryInfo != null && !listNuroPatientReceptionHistoryInfo.isEmpty()){
 				for(NuroPatientReceptionHistoryInfo item : listNuroPatientReceptionHistoryInfo){
 					NuroModelProto.NuroPatientReceptionHistoryListItemInfo.Builder nuroPatientReceptionHistoryInfo = NuroModelProto.NuroPatientReceptionHistoryListItemInfo.newBuilder();
 					
 					BeanUtils.copyProperties(item, nuroPatientReceptionHistoryInfo, getLanguage(vertx, sessionId));

 					response.addGrdJubsuHistoryList(nuroPatientReceptionHistoryInfo);
 				}
 			}
         	
         	List<NuroPatientCommentInfo> listNuroPatientCommentInfo = out1001Repository.getNuroPatientCommentListItemInfo(language, hospCode, request.getPatientCode());
         	if(listNuroPatientCommentInfo != null && !listNuroPatientCommentInfo.isEmpty()){
 				for(NuroPatientCommentInfo item: listNuroPatientCommentInfo){
 					NuroModelProto.NuroPatientCommentListItemInfo.Builder nuroPatientCommentListinfo = NuroModelProto.NuroPatientCommentListItemInfo.newBuilder();
 					
 					BeanUtils.copyProperties(item, nuroPatientCommentListinfo, getLanguage(vertx, sessionId));
 					
 					response.addGrdCommentList(nuroPatientCommentListinfo);
 				}
 			}
     	}
     	List<NuroPatientInsuranceInfo> listNuroPatientInsuranceInfo = out1001Repository.getNuroPatientInsuranceListItemInfo(language, hospCode, 
         		request.getPatientCode(), request.getComingDate());
     	if (listNuroPatientInsuranceInfo != null && !listNuroPatientInsuranceInfo.isEmpty()) {
             for (NuroPatientInsuranceInfo item : listNuroPatientInsuranceInfo) {
                 NuroModelProto.NuroPatientInsuranceListItemInfo.Builder patientInsuranceInfo = NuroModelProto.NuroPatientInsuranceListItemInfo.newBuilder();
                 
                 BeanUtils.copyProperties(item, patientInsuranceInfo, getLanguage(vertx, sessionId));

                 response.addGrdGongbiCodeList(patientInsuranceInfo);
             }
         }
     	
     	List<NuroPatientDetailInfo> listNuroPatientDetailItemInfo = out1001Repository.getNuroPatientDetailListItemInfo(language, hospCode,
					request.getPatientCode(),request.getComingDate());
     	if(listNuroPatientDetailItemInfo != null && !listNuroPatientDetailItemInfo.isEmpty()){
				for(NuroPatientDetailInfo item : listNuroPatientDetailItemInfo){
					NuroModelProto.NuroPatientDetailListItemInfo.Builder patientDefailInfo = NuroModelProto.NuroPatientDetailListItemInfo.newBuilder();
					
					BeanUtils.copyProperties(item, patientDefailInfo, getLanguage(vertx, sessionId));
					List<NuroOUT1001U01LayGongbiCodeInfo> listNuroOUT1001U01LayGongbiCodeInfo = out1002Repository.getNuroOUT1001U01LayGongbiCode(hospCode, item.getPkout1001());
					if (listNuroOUT1001U01LayGongbiCodeInfo != null && !listNuroOUT1001U01LayGongbiCodeInfo.isEmpty()) {
						if (!StringUtils.isEmpty(listNuroOUT1001U01LayGongbiCodeInfo.get(0).getGongbiCode1())) {
							patientDefailInfo.setInsurCode1(listNuroOUT1001U01LayGongbiCodeInfo.get(0).getGongbiCode1());
						}
						if (!StringUtils.isEmpty(listNuroOUT1001U01LayGongbiCodeInfo.get(0).getGongbiCode2())) {
							patientDefailInfo.setInsurCode2(listNuroOUT1001U01LayGongbiCodeInfo.get(0).getGongbiCode2());
						}
						if (!StringUtils.isEmpty(listNuroOUT1001U01LayGongbiCodeInfo.get(0).getGongbiCode3())) {
							patientDefailInfo.setInsurCode3(listNuroOUT1001U01LayGongbiCodeInfo.get(0).getGongbiCode3());
						}
						if (!StringUtils.isEmpty(listNuroOUT1001U01LayGongbiCodeInfo.get(0).getGongbiCode4())) {
							patientDefailInfo.setInsurCode4(listNuroOUT1001U01LayGongbiCodeInfo.get(0).getGongbiCode4());
						}
					}
					
					response.addGrdJubsuList(patientDefailInfo);
				}
			}
		return response.build();
	}
}
