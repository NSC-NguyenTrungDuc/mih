package nta.med.kcck.api.socket.vertx;

import nta.med.service.ihis.proto.OcsoServiceProto;

/**
 * @author dainguyen.
 */
public class OcsoVerticle extends ApiVerticle {

    public OcsoVerticle() {
        super(OcsoServiceProto.class, OcsoServiceProto.getDescriptor());
    }

    @Override
    protected void doStart() throws Exception {

    }

    @Override
    protected void doStop() throws Exception {

    }

    @Override
    protected boolean isProcessable() {
        return false;
    }

    @Override
    boolean isNodeBasedHandle() {
        return false;
    }
}
