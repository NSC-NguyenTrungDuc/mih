package nta.med.service.ihis.handler.chts;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.cht.Cht0117;
import nta.med.core.domain.cht.Cht0118;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cht.Cht0117Repository;
import nta.med.data.dao.medi.cht.Cht0118Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsModelProto.CHT0117GrdCHT0117InitListItemInfo;
import nta.med.service.ihis.proto.ChtsModelProto.CHT0117GrdCHT0118InitListItemInfo;
import nta.med.service.ihis.proto.ChtsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.util.Calendar;
import java.util.Date;

@Transactional
@Service
@Scope("prototype")
public class CHT0117TransactionalHandler extends ScreenHandler<ChtsServiceProto.CHT0117TransactionalRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0117TransactionalHandler.class);
    @Resource
    private Cht0117Repository cht0117Repository;
    @Resource
    private Cht0118Repository cht0118Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0117TransactionalRequest request) throws Exception {
        String hospitalCode = getHospitalCode(vertx, sessionId);
        SystemServiceProto.UpdateResponse.Builder response = executeHandler(request, hospitalCode, getLanguage(vertx, sessionId));
        if (!response.getResult()) {
            throw new ExecutionException(response.build());
        }
        return response.build();
    }

    public SystemServiceProto.UpdateResponse.Builder executeHandler(ChtsServiceProto.CHT0117TransactionalRequest request, String hospitalCode, String language) {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();

        for (CHT0117GrdCHT0117InitListItemInfo item : request.getListInput1List()) {
            if (DataRowState.ADDED.getValue().equals(item.getRowState())) {
                String layCheck = cht0117Repository.getCHT0117TransactionalLayCheck(item.getBuwi(), DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), hospitalCode, language);
                if (!StringUtils.isEmpty(layCheck) && layCheck.equalsIgnoreCase("Y")) {
                    response.setResult(false);
                    response.setMsg("MSG005_MSG");
                    return response;
                } else {
                    Calendar cal = Calendar.getInstance();
                    cal.setTime(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
                    cal.add(Calendar.DATE, -1);
                    cht0117Repository.updateCHT0117Transactional(cal.getTime(), item.getBuwi(), DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD), hospitalCode, language);

                    Cht0117 cht0117 = new Cht0117();
                    cht0117.setSysDate(new Date());
                    cht0117.setSysId(request.getUserId());
                    cht0117.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
                    cht0117.setEndDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
                    cht0117.setBuwi(item.getBuwi());
                    cht0117.setBuwiName(item.getBuwiName());
                    Double sortKey = CommonUtils.parseDouble(item.getSortKey());
                    cht0117.setSortKey(sortKey);
                    cht0117.setRemark(item.getRemark());
                    cht0117.setHospCode(hospitalCode);
                    cht0117.setLanguage(language);
                    cht0117Repository.save(cht0117);
                }
            } else if (DataRowState.MODIFIED.getValue().equals(item.getRowState())) {
                cht0117Repository.updateCHT0117TransactionalModified(
                        request.getUserId(),
                        item.getBuwiName(),
                        CommonUtils.parseDouble(item.getSortKey()),
                        item.getRemark(),
                        item.getBuwi(),
                        DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD),
                        hospitalCode,
                        language);
            } else if (DataRowState.DELETED.getValue().equals(item.getRowState())) {
                Calendar cal = Calendar.getInstance();
                cal.setTime(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
                cal.add(Calendar.DATE, -1);
                cht0117Repository.updateCHT0117Transactional(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD), item.getBuwi(), cal.getTime(), hospitalCode, language);
                cht0117Repository.deleteCHT0117TransactionalDeleted(item.getBuwi(), DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), hospitalCode, language);
            }
        }

        for (CHT0117GrdCHT0118InitListItemInfo item : request.getListInput2List()) {
            if (DataRowState.ADDED.getValue().equals(item.getRowState())) {
                String layCheck = cht0118Repository.getCHT0117layCheckCht0118(hospitalCode, language, item.getBuwi(), item.getSubBuwi(), DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
                if (!StringUtils.isEmpty(layCheck) && layCheck.equalsIgnoreCase("Y")) {
                    response.setResult(false);
                    response.setMsg("MSG006_MSG");
                    return response;
                } else {
                    Calendar cal = Calendar.getInstance();
                    cal.setTime(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
                    cal.add(Calendar.DATE, -1);
                    cht0118Repository.updateCHT0117TransactionalCht0118(cal.getTime(), item.getBuwi(), item.getSubBuwi(), DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD), hospitalCode, language);

                    Cht0118 cht0118 = new Cht0118();
                    cht0118.setSysDate(new Date());
                    cht0118.setSysId(request.getUserId());
                    cht0118.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
                    cht0118.setEndDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
                    cht0118.setBuwi(item.getBuwi());
                    //
                    String subBuwi = cht0118Repository.getCHT0117LayNextSubBuwiCd(hospitalCode, language);
                    if (!StringUtils.isEmpty(subBuwi)) {
                        cht0118.setSubBuwi(subBuwi);
                    } else {
                        cht0118.setSubBuwi("001");
                    }
                    //
                    cht0118.setSubBuwiName(item.getSubBuwiName());
                    Double sortKey = CommonUtils.parseDouble(item.getSortKey());
                    if (sortKey != null) {
                        cht0118.setSortKey(sortKey);
                    }
                    cht0118.setRemark(item.getRemark());
                    Double nosaiJyRate = CommonUtils.parseDouble(item.getNosaiJyRate());
                    if (nosaiJyRate != null) {
                        cht0118.setNosaiJyRate(nosaiJyRate);
                    }
                    cht0118.setHospCode(hospitalCode);
                    cht0118.setLanguage(language);
                    cht0118Repository.save(cht0118);
                }
            } else if (DataRowState.MODIFIED.getValue().equals(item.getRowState())) {
                cht0118Repository.updateCHT0117TransactionalCht0118Modified(
                        request.getUserId(),
                        item.getSubBuwiName(),
                        CommonUtils.parseDouble(item.getSortKey()),
                        item.getRemark(),
                        CommonUtils.parseDouble(item.getNosaiJyRate()),
                        item.getBuwi(),
                        item.getSubBuwi(),
                        DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD),
                        hospitalCode,
                        language);
            } else if (DataRowState.DELETED.getValue().equals(item.getRowState())) {
                Calendar cal = Calendar.getInstance();
                cal.setTime(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
                cal.add(Calendar.DATE, -1);
                cht0118Repository.updateCHT0117TransactionalCht0118(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD), item.getBuwi(), item.getSubBuwi(), cal.getTime(), hospitalCode, language);
                cht0118Repository.deleteCHT0117TransactionalCht0118Deleted(
                        item.getBuwi(), item.getSubBuwi(), DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), hospitalCode, language);
            }
        }
        response.setResult(true);
        return response;
    }
}