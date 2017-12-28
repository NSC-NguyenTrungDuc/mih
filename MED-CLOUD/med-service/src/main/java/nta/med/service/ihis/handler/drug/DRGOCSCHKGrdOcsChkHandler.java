package nta.med.service.ihis.handler.drug;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.model.ihis.drug.DRGOCSCHKGrdOcsChkInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrugModelProto;
import nta.med.service.ihis.proto.DrugServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class DRGOCSCHKGrdOcsChkHandler extends ScreenHandler<DrugServiceProto.DRGOCSCHKGrdOcsChkRequest, DrugServiceProto.DRGOCSCHKGrdOcsChkResponse> {
	private static final Log LOG = LogFactory.getLog(DRGOCSCHKGrdOcsChkHandler.class);
	@Resource
	private Inv0110Repository inv0110Repository;

	@Override
	@Transactional(readOnly = true)
	public DrugServiceProto.DRGOCSCHKGrdOcsChkResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRGOCSCHKGrdOcsChkRequest request) throws Exception {
		 List<DRGOCSCHKGrdOcsChkInfo> listObject = inv0110Repository.getDRGOCSCHKGrdOcsChkInfo(getHospitalCode(vertx, sessionId), request.getJaeryoCode(),
         		request.getJaeryoName(), request.getPreSmallCode(), request.getSmallCode(), request.getDrgPackYn(), request.getPhamarcyYn(),
         		request.getPowderYn(), request.getHubalYn(), request.getMayakYn(), request.getBeforeUseYn(), CommonUtils.parseInteger(request.getPageNumber()), getLanguage(vertx, sessionId));
         DrugServiceProto.DRGOCSCHKGrdOcsChkResponse.Builder response = DrugServiceProto.DRGOCSCHKGrdOcsChkResponse.newBuilder();
         if(!CollectionUtils.isEmpty(listObject)) {
         	for(DRGOCSCHKGrdOcsChkInfo item : listObject) {
         		DrugModelProto.DRGOCSCHKGrdOcsChkInfo.Builder info = DrugModelProto.DRGOCSCHKGrdOcsChkInfo.newBuilder();
         		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
         		response.addListItem(info);
         	}
         }
		return response.build();
	}
}
