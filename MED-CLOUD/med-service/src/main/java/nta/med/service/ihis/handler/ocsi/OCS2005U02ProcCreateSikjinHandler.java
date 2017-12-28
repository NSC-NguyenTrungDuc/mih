package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02ProcCreateSikjinRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02ProcCreateSikjinResponse;

@Service
@Scope("prototype")
public class OCS2005U02ProcCreateSikjinHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02ProcCreateSikjinRequest, OcsiServiceProto.OCS2005U02ProcCreateSikjinResponse> {

	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional
	public OCS2005U02ProcCreateSikjinResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02ProcCreateSikjinRequest request) throws Exception {
		OcsiServiceProto.OCS2005U02ProcCreateSikjinResponse.Builder response = OcsiServiceProto.OCS2005U02ProcCreateSikjinResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String fkinp1001 = "0";
		String ipwonDate = "";
		
		List<DataStringListItemInfo> result;
		result = inp1001Repository.getPkInp1001Ocs2005U02(hospCode, request.getBunho(), request.getMpressedJaewonYn());
		if(CollectionUtils.isEmpty(result)){
			result = inp1003Repository.OCS2005U02getReserFkInp1001(hospCode, request.getBunho(), "0");
		}
		
		if(CollectionUtils.isEmpty(result)){
			fkinp1001 ="0";
		}else{
			for(DataStringListItemInfo item : result){
				fkinp1001 = item.getItem();
			}
		}
		
		result = inp1001Repository.getInpwonDateOcs2005U02(hospCode, request.getBunho(), request.getMpressedJaewonYn());
		if(CollectionUtils.isEmpty(result)){
			result = inp1003Repository.OCS2005U02getReserDate(hospCode, request.getBunho(), "0");
		}
		
		if(CollectionUtils.isEmpty(result)){
			ipwonDate ="";
		}else{
			for(DataStringListItemInfo item : result){
				ipwonDate = item.getItem();
			}
		}
		
		String result1 = ocs2005Repository.OCS2005U02ProcCreateSikjin(request.getFromDate(), request.getFromBld(), request.getBunho(), hospCode, CommonUtils.parseDouble(fkinp1001),
				request.getUpdId(), request.getCommentGubun(), CommonUtils.parseInteger(request.getSikjinGubun()), request.getIudGubun(), request.getNomimono(), ipwonDate,
				request.getSikgubun1Th(), request.getSikjong1Th(), request.getJusik1Th(), request.getBusik1Th(), request.getSikgubun2Th(), request.getSikjong2Th(), 
				request.getJusik2Th(), request.getBusik2Th(), request.getSikgubun3Th(), request.getSikjong3Th(), request.getJusik3Th(), request.getBusik3Th(),
				request.getSikgubun4Th(), request.getSikjong4Th(), request.getJusik4Th(), request.getBusik4Th(), request.getSikgubun5Th(), request.getSikjong5Th(),
				request.getJusik5Th(), request.getBusik5Th());
		
		if(result1 == null){
			result1 = "";
		}
		
		ComboListItemInfo item;
		if(fkinp1001 == "0")
			item = new ComboListItemInfo("0", result1);
		else
			item = new ComboListItemInfo("", result1);
		
		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		response.setProItem(info);
		
		
		return response.build();
	}

}
