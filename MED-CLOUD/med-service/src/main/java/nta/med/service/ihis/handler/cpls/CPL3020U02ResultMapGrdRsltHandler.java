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
import nta.med.data.model.ihis.cpls.Cpl3020U02ResultMapGrdRsltInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ResultMapGrdRsltRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ResultMapGrdRsltResponse;

@Service
@Scope("prototype")
public class CPL3020U02ResultMapGrdRsltHandler extends ScreenHandler<CPL3020U02ResultMapGrdRsltRequest, CPL3020U02ResultMapGrdRsltResponse>{
	
	@Resource
	private Cpl0891Repository cpl0891Repository;
	
	@Override
	public boolean isValid(CPL3020U02ResultMapGrdRsltRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getResultDate()) && DateUtil.toDate(request.getResultDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public CPL3020U02ResultMapGrdRsltResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U02ResultMapGrdRsltRequest request) throws Exception {
		CPL3020U02ResultMapGrdRsltResponse.Builder response = CPL3020U02ResultMapGrdRsltResponse.newBuilder();
		List<Cpl3020U02ResultMapGrdRsltInfo> list = cpl0891Repository.getCpl3020U02ResultMapGrdRsltInfo(getHospitalCode(vertx, sessionId), 
				request.getJangbiCode(), DateUtil.toDate(request.getResultDate(), DateUtil.PATTERN_YYMMDD), request.getSampleId());
		if(!CollectionUtils.isEmpty(list)){
			for(Cpl3020U02ResultMapGrdRsltInfo item : list){
				CplsModelProto.CPL3020U02ResultMapGrdRsltInfo.Builder info = CplsModelProto.CPL3020U02ResultMapGrdRsltInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdResultList(info);
			}
		}
		return response.build();
	}

}
