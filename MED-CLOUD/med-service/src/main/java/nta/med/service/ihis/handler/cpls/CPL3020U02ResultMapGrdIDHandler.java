package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl0891Repository;
import nta.med.data.model.ihis.cpls.Cpl3020U02ResultMapGrdIdInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ResultMapGrdIDRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ResultMapGrdIDResponse;


@Service
@Scope("prototype")
public class CPL3020U02ResultMapGrdIDHandler extends ScreenHandler<CPL3020U02ResultMapGrdIDRequest, CPL3020U02ResultMapGrdIDResponse>{
	@Resource
	private Cpl0891Repository cpl0891Repository;
	
	@Override
	@Transactional(readOnly = true)
	public boolean isValid(CPL3020U02ResultMapGrdIDRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if ((!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null)
				||(!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null)) {
			return false;
		}
		return true;
	}

	@Override
	public CPL3020U02ResultMapGrdIDResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U02ResultMapGrdIDRequest request) throws Exception {
		CPL3020U02ResultMapGrdIDResponse.Builder response = CPL3020U02ResultMapGrdIDResponse.newBuilder();
		List<Cpl3020U02ResultMapGrdIdInfo> list = cpl0891Repository.getCpl3020U02ResultMapGrdIdInfo(getHospitalCode(vertx, sessionId), request.getJangbiCode(), request.getSpecimenSer(), 
				DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD), request.getAllYn());
		if(!CollectionUtils.isEmpty(list)){
			for(Cpl3020U02ResultMapGrdIdInfo item : list){
				CplsModelProto.CPL3020U02ResultMapGrdIDInfo.Builder info = CplsModelProto.CPL3020U02ResultMapGrdIDInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdIDList(info);
			}
		}
		return response.build();
	}

}
