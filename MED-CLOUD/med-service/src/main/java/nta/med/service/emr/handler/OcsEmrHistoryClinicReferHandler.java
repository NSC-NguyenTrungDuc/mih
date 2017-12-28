package nta.med.service.emr.handler;

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

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.Out2016Repository;
import nta.med.data.model.ihis.emr.OCS2015U03AllLinkClinicInfo;
import nta.med.data.model.ihis.emr.OCS2015U03OrderGubunInfo;
import nta.med.data.model.ihis.nuro.NuroPatientReceptionHistoryInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OcsEmrHistoryClinicReferRequest;
import nta.med.service.emr.proto.EmrServiceProto.OcsEmrHistoryClinicReferResponse;

@Service
@Scope("prototype")
public class OcsEmrHistoryClinicReferHandler extends ScreenHandler<EmrServiceProto.OcsEmrHistoryClinicReferRequest, EmrServiceProto.OcsEmrHistoryClinicReferResponse>{
	private static final Log LOGGER = LogFactory.getLog(OcsEmrHistoryClinicReferHandler.class);
	@Resource                                                                                                       
	private Out2016Repository out2016Repository;
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsEmrHistoryClinicReferResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsEmrHistoryClinicReferRequest request) throws Exception {
		EmrServiceProto.OcsEmrHistoryClinicReferResponse.Builder response = EmrServiceProto.OcsEmrHistoryClinicReferResponse.newBuilder();
		String hospName = null;
		String language = getLanguage(vertx, sessionId);
		List<OCS2015U03AllLinkClinicInfo> linkClinics = out2016Repository.getOCS2015U03AllLinkClinicInfo(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(linkClinics)){
			for(OCS2015U03AllLinkClinicInfo clinic : linkClinics){
				EmrModelProto.OcsEmrHistoryClinicReferItemInfo.Builder infoNode1 = EmrModelProto.OcsEmrHistoryClinicReferItemInfo.newBuilder();
					if(!StringUtils.isEmpty(clinic.getHospCodeLink())){
						infoNode1.setHopsCode(clinic.getHospCodeLink());
					}
				List<Bas0001> bas0001 = bas0001Repository.findLatestByHospCode(clinic.getHospCodeLink());
				if(!CollectionUtils.isEmpty(bas0001)){
					hospName = bas0001.get(0).getYoyangName();
					if(!StringUtils.isEmpty(hospName)){
						infoNode1.setHopsName(hospName);
					}
				}
				List<NuroPatientReceptionHistoryInfo> listNuroPatientReceptionHistoryInfo = out1001Repository.getNuroPatientReceptionHistoryInfo(language, clinic.getHospCodeLink(), clinic.getBunhoLink());
	    		if(listNuroPatientReceptionHistoryInfo != null && !listNuroPatientReceptionHistoryInfo.isEmpty()){
	    			for(NuroPatientReceptionHistoryInfo item : listNuroPatientReceptionHistoryInfo){
	    				EmrModelProto.OcsEmrPatientReceptionHistoryListItemInfo.Builder infoNode2 = EmrModelProto.OcsEmrPatientReceptionHistoryListItemInfo.newBuilder();
	    				BeanUtils.copyProperties(item, infoNode2, language);
	    				
	    				List<OCS2015U03OrderGubunInfo> listGubun = ocs1003Repository.getOCS2015U03OrderGubunInfo(clinic.getHospCodeLink(), clinic.getBunhoLink(), item.getPkout1001());
	    				for (OCS2015U03OrderGubunInfo orderItem : listGubun) {
	    					EmrModelProto.OCS2015U03OrderGubunInfo.Builder infoNode3 = EmrModelProto.OCS2015U03OrderGubunInfo.newBuilder();
	    					BeanUtils.copyProperties(orderItem, infoNode3, language);
	    					infoNode2.addOrderGubun(infoNode3);
	    				}
	    				infoNode1.addLst(infoNode2);
	    			}
	    		}
	    		response.addLst(infoNode1);
			}
		}
		return response.build();
	}

}
