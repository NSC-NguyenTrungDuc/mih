package nta.med.service.ihis.handler.adma;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.Adm1100;
import nta.med.core.domain.adm.Adm1110;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm1100Repository;
import nta.med.data.dao.medi.adm.Adm1110Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto.ADM201UGrdDicDetailItemInfo;
import nta.med.service.ihis.proto.AdmaModelProto.ADM201UGrdDicMasterItemInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class ADM201USaveLayoutHandler extends ScreenHandler<AdmaServiceProto.ADM201USaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM201USaveLayoutHandler.class);

    @Resource
    private Adm1100Repository adm1100Repository;

    @Resource
    private Adm1110Repository adm1110Repository;

    @Override
    @Route(global = true)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM201USaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String language = getLanguage(vertx, sessionId);
        response = saveLayout(request, language);
        if (!response.getResult()) {
            throw new ExecutionException(response.build());
        }
        return response.build();
    }

    public SystemServiceProto.UpdateResponse.Builder saveLayout(AdmaServiceProto.ADM201USaveLayoutRequest request, String language) {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        List<ADM201UGrdDicMasterItemInfo> listGroupItem = request.getGrdDicMasterItemInfoList();
        if (!CollectionUtils.isEmpty(listGroupItem)) {
            for (ADM201UGrdDicMasterItemInfo item : listGroupItem) {
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                    Adm1100 adm1100 = new Adm1100();
                    adm1100.setColId(item.getColId());
                    adm1100.setColNm(item.getColNm());
                    adm1100.setColTp(item.getColTp());
                    adm1100.setColLen(CommonUtils.parseDouble(item.getColLen()));
                    adm1100.setColScal(CommonUtils.parseDouble(item.getColScal()));
                    adm1100.setCmmt(item.getCmmt());
                    adm1100.setCrMemb(request.getUserId());
                    adm1100.setCrTime(new Date());
                    adm1100Repository.save(adm1100);
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    if (adm1100Repository.updateAdm1100SaveLayout(item.getColNm(), item.getColTp(), CommonUtils.parseDouble(item.getColLen()),
                            CommonUtils.parseDouble(item.getColScal()), item.getCmmt(), request.getUserId(), new Date(), item.getColId()) <= 0) {
                        response.setResult(false);
                        return response;
                    }
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                    if (adm1100Repository.deleteAdm1100SaveLayout(item.getColId()) <= 0) {
                        response.setResult(false);
                        return response;
                    }
                }
            }
        }

        List<ADM201UGrdDicDetailItemInfo> listSystemItem = request.getGrdDicDetailItemInfoList();
        if (!CollectionUtils.isEmpty(listSystemItem)) {
            for (ADM201UGrdDicDetailItemInfo item : listSystemItem) {
                if (item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                    Adm1110 adm1110 = new Adm1110();
                    adm1110.setColId(item.getColId());
                    adm1110.setCode(item.getCode());
                    adm1110.setCodeNm(item.getCodeNm());
                    adm1110.setCrMemb(request.getUserId());
                    adm1110.setCrTime(new Date());
                    adm1110.setLanguage(language);
                    adm1110Repository.save(adm1110);
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                    if (adm1110Repository.updateAdm1110SaveLayout(item.getCodeNm(), request.getUserId(), new Date(), item.getColId(), item.getCode(), language) <= 0) {
                        response.setResult(false);
                        return response;
                    }
                } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                    if (adm1110Repository.deleteAdm1110SaveLayout(item.getColId(), item.getCode(), language) <= 0) {
                        response.setResult(false);
                        return response;
                    }
                }
            }
        }

        response.setResult(true);
        return response;
    }
}
