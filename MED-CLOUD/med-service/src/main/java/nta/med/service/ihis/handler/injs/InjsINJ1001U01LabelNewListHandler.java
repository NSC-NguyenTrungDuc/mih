package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.injs.InjsINJ1001U01LabelNewListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InjsINJ1001U01LabelNewListHandler extends ScreenHandler<InjsServiceProto.InjsINJ1001U01LabelNewListRequest, InjsServiceProto.InjsINJ1001U01LabelNewListResponse>{
	private static final Log LOG = LogFactory.getLog(InjsINJ1001U01LabelNewListHandler.class);
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Override
	public boolean isValid(InjsServiceProto.InjsINJ1001U01LabelNewListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.InjsINJ1001U01LabelNewListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.InjsINJ1001U01LabelNewListRequest request) throws Exception {
		List<InjsINJ1001U01LabelNewListItemInfo> listObject = ocs1003Repository.getInjsINJ1001U01LabelNewListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
        		request.getGwa(), request.getDoctor(), request.getBunho(), DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD), request.getGroupSer(), request.getMixGroup(), request.getFkinj1001());
        InjsServiceProto.InjsINJ1001U01LabelNewListResponse.Builder response = InjsServiceProto.InjsINJ1001U01LabelNewListResponse.newBuilder();
        if (!CollectionUtils.isEmpty(listObject)) {
        	for (InjsINJ1001U01LabelNewListItemInfo item : listObject) {
        		InjsModelProto.InjsINJ1001U01LabelNewListItemInfo.Builder info = InjsModelProto.InjsINJ1001U01LabelNewListItemInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getBunho())) {
        			info.setBunho(item.getBunho());
        		}
        		if (!StringUtils.isEmpty(item.getSuname())) {
        			info.setSuname(item.getSuname());
        		}
        		if (!StringUtils.isEmpty(item.getSuname2())) {
        			info.setSuname2(item.getSuname2());
        		}
        		if (item.getAge() != null) {
        			info.setAge(item.getAge().toString());
        		}
        		if (!StringUtils.isEmpty(item.getSex())) {
        			info.setSex(item.getSex());
        		}
        		if (item.getJubsuDate() != null) {
        			info.setJubsuDate(item.getJubsuDate().toString());
        		}
        		if (item.getCnt() != null) {
        			info.setCnt(String.format("%.0f", item.getCnt()));
        		}
        		if (item.getSuryang() != null) {
        			info.setCnt(String.format("%.0f", item.getSuryang()));
        		}
        		if (!StringUtils.isEmpty(item.getDanuiName())) {
        			info.setDanuiName(item.getDanuiName());
        		}
        		if (!StringUtils.isEmpty(item.getBogyongName())) {
        			info.setBogyongName(item.getBogyongName());
        		}
        		if (!StringUtils.isEmpty(item.getJusaName())) {
        			info.setJusaName(item.getJusaName());
        		}
        		if (!StringUtils.isEmpty(item.getJaeryoName())) {
        			info.setJaeryoName(item.getJaeryoName());
        		}
        		if (!StringUtils.isEmpty(item.getOrderRemark())) {
        			info.setOrderRemark(item.getOrderRemark());
        		}
        		if (!StringUtils.isEmpty(item.getDataGubun())) {
        			info.setDataGubun(item.getDataGubun());
        		}
        		if (!StringUtils.isEmpty(item.getMixYn())) {
        			info.setMixYn(item.getMixYn());
        		}
        		response.addLabelNewListItem(info);
        	}
        }
		return response.build();
	}

}
